var app = angular.module('testik', ['cp.ngConfirm','ui-notification','ckeditor','ngQuill', 'ngSanitize','ngFileUpload','drahak.hotkeys','ngWebSocket','ysilvela.socket-io'],  function($httpProvider) {

    //$httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
}) .config(function($locationProvider, NotificationProvider) {
    //$locationProvider.html5Mode({
      //enabled: true,
      //requireBase: false
    //});
    NotificationProvider.setOptions({
        delay: 10000,
        startTop: 20,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'right',
        positionY: 'top'
    });
});
app.factory('mySocket', function (socketFactory) {
  return socketFactory({
    ioSocket: io.connect('wss://ws.naurok.com.ua/')
  });
});
app.controller('ClassroomCtrl',function ($scope, $websocket, $interval, $window, $timeout, mySocket) {
    $scope.init = function(room, active ,session_id = false,username = false, uuid = false){
        $scope.room = room;
        $scope.session_id = session_id;
        $scope.uuid = uuid;
        $scope.username = username;
        $scope.active = active;
        $scope.joined = false;
        $scope.isAdmin = (!$scope.username ? true : false);
       // var socket = io.connect('http://localhost:8081');
        console.log(mySocket);
        //var ws = $websocket.$new('ws://127.0.0.1:8081/?room='+room+'&session_id='+session_id);
        //var ws = $websocket('wss:///naurok.com.ua:2053/');
      //  console.log(active);
        $timeout(function(){
         var data =  {'action':'join','room':$scope.room, 'session':($scope.session_id ? $scope.session_id : 'admin'), 'name': $scope.username};
         mySocket.emit('join', data);
        },100);
        $scope.start = function(){
            //var ws = $websocket.$new('tcp://127.0.0.1:1234');
            var data =  {'action':'start','room':$scope.room};
            //console.log(data);
            mySocket.emit('start', data);
            $scope.initScene = false;
            $scope.scoreboard = true;

        //    ws.send('your message');
        }

        $scope.finish = function(){
            //var ws = $websocket.$new('tcp://127.0.0.1:1234');
            var data =  {'action':'stop','room':$scope.room};
            //console.log(data);
            mySocket.emit('stop', data);
            //ws.send(JSON.stringify(data));
            //$scope.initScene = false;
            $scope.finishScene = true;
            //$interval.cancel($scope.stop);

        //    ws.send('your message');
        }
        /*
        $scope.join = function(){
            $scope.nameSet = true;
            console.log('join');
            var data =  {'action':'join','room':$scope.room,'user':$scope.username};
            console.log(data);
            ws.$emit('ping',data);
      } */

        $scope.delete = function(client_id){

            var data =  {'action':'remove','room':room, 'client_id':client_id};
            mySocket.emit('remove', data);
            //ws.send(JSON.stringify(data));
        }

        $scope.cancel = function(){

             var data =  {'action':'cancel','room':room};
             //console.log(data);
             mySocket.emit('cancel', data);
             //ws.send(JSON.stringify(data));
        }
      //  $interval(function(){
      //       console.log('get score');
      //       $scope.getScore();
      // },3000);
        $scope.getScore = function(){
            var data =  {'action':'scoreboard', 'room':$scope.room};
            mySocket.emit('scoreboard', data);
            //ws.send(JSON.stringify(data));
            //console.log(data);
        }

        if( $scope.active == 2 && $scope.isAdmin){
            $scope.startChallenge = true;
            $scope.getScore();
        }

        // instance of ngWebsocket, handled by $websocket service
        //var ws = $websocket.$new('ws://127.0.0.1:8000/'); // instance of ngWebsocket, handled by $websocket service
    //    if($scope.session_id != false){
        //    var data =  {'action':'join','room':$scope.room,'user':$scope.username};
        //    ws.$emit('ping',data);
        //}
        if(active == 0){
            if(!$scope.isAdmin){
                $window.location.href = '/test/complete/'+$scope.uuid;
            }
            $scope.finishScene = true;
            $scope.scoreboard = true;
        }
        if(active == 1){
            $scope.initScene = true;
        }
        if(active == 2){
            $scope.startChallenge = true;
        }

        $scope.usersCount = function(){
            if($scope.userList){
                  return $scope.userList.reduce(function (n, person) {
                      return n + (person.name != false);
                  }, 0);
            }else{
                  return 0;
            }
        }
        mySocket.on('participants', function (event) {
             console.log(event);
             $scope.joined = true;
             $scope.userList = event.userList;
        });

        mySocket.on('removed', function (event) {
             if(!$scope.isAdmin){
                   $window.location.href = '/test/join';
             }
             $scope.userList = event.userList;
        });

        mySocket.on('startChallenge', function (event) {
              $scope.startChallenge = true;
              $scope.getScore();
        });
        mySocket.on('stopChallenge', function (event) {
             console.log('stopChallenge');
             if(!$scope.isAdmin){
                 $window.location.href = '/test/complete/'+$scope.uuid+'?complete';
             }
        });

        mySocket.on('scoreboard', function (event) {
             console.log(event);
             $scope.scoreboard = event;
        });
        /*
        ws.onMessage(function (evt) {
            // console.log(evt);
             var event = JSON.parse(evt.data);
             $scope.$apply(function () {
                       $timeout(function(){
                             if(event.action == 'startChallenge'){
                                $scope.startChallenge = true;
                            }
                             if(event.action == 'participants'){
                                   $scope.joined = true;
                                   $scope.userList = event.userList;
                             }
                             if(event.action == 'removed'){
                                   if(!$scope.isAdmin){
                                         $window.location.href = '/test/join';
                                   }
                                   $scope.userList = event.userList;
                             }
                             if(event.action == 'scoreboard'){
                                   $scope.scoreboard = event;
                             }
                             if(event.action == 'stopChallenge'){
                                 if(!$scope.isAdmin){
                                      $window.location.href = '/test/complete/'+$scope.uuid;
                                 }
                                  //$scope.scoreboard = event;
                             }
                      },100);
                });



        }); */
        /*
        ws.onClose(function (event) {
            //var data =  {'action':'close','room':$scope.room,'id':$scope.session_id};
            //ws.$emit('ping',data);
             console.log("Connection closed.");
      }); */


    }


});


app.controller('TestCtrl',function ($scope, $sce, $location, $window, $interval, SessionFactory, $timeout) {

    $scope.init = function(document_id, session_id, time){

        $scope.test.sound.success = new Howl({ src: ['naurok_assets/sounds/success-1.mp3'] });
        $scope.test.sound.wrong = new Howl({ src: ['naurok_assets/sounds/wrong-1.mp3'] });
        $scope.test.time = time;
        SessionFactory.getSession(session_id).then(function successCallback(response) {
            $scope.test.questions = response.data.questions;
            $scope.test.document = response.data.document;
            $scope.test.responses = response.data.responses;
            $scope.test.session = response.data.session;
            $scope.test.settings = response.data.settings;
            //$scope.timerLength = 400;
            if($scope.test.settings.shuffle_question == false && $scope.test.session.latest_question){
                var index = $scope.test.getIndex($scope.test.session.latest_question.toString());
                //console.log(index,$scope.test.session.latest_question);
                $scope.test.activeNumber = index+2;
                $scope.test.question = response.data.questions[index+1];
                $scope.test.active = $scope.test.question.id;
            }else{
                $scope.test.question = response.data.questions[0];
                $scope.test.active = $scope.test.question.id;
            }

            if($scope.test.settings.shuffle_options == 1){
                $scope.test.randomList($scope.test.question.options);
            }
            $scope.layout.resize();
        //    $scope.test.scene = 2;
            if($scope.test.settings.show_timer == 1){
                  $scope.test.timer();
            }
        }, function errorCallback(response) {
            //$location.path('/');
            console.log(response);
        });
    }
     angular.element($window).bind('resize', function(){
        $scope.layout.resize();
        $scope.$digest();
    });
    $scope.calcStyle = function(){

    }
    $scope.disableSave = false;

    $scope.layout = {
        resize:function(){
            $scope.layout.container.width = document.querySelectorAll('.test-container-inner')[0].offsetWidth;
            $scope.layout.container.height = document.querySelectorAll('.test-container-inner')[0].offsetHeight;
            $scope.layout.options.width = document.querySelectorAll('.test-options-grid')[0].offsetWidth,
            $scope.layout.options.count = $scope.test.question.options.length;
            $scope.layout.question.type = $scope.test.question.type;
            $scope.layout.question.hasImage = ($scope.test.question.image ? true : false);
            $scope.layout.options.hasImage = $scope.test.question.optionHasImage;
            $scope.layout.options.maxLength = $scope.test.question.optionMaxLength;
            $scope.layout.question.contentLength = $scope.test.question.questionLength;
            $timeout(function(){
                $scope.layout.question.content.innerHeight = document.querySelectorAll('.test-content-text-inner')[0].offsetHeight;
            },300);
            if($scope.layout.options.hasImage){
                if($scope.layout.options.count <= 5){
                    $scope.layout.options.lines = 1;
                    $scope.layout.options.itemsInline = $scope.layout.options.count;
                }else{
                    $scope.layout.options.lines = 2;
                    $scope.layout.options.itemsInline = $scope.layout.options.count+($scope.layout.options.count%2)/2;
                }
            }else{
                if($scope.layout.options.maxLength > 100){
                    $scope.layout.options.lines = $scope.layout.options.count;
                    $scope.layout.options.itemsInline = $scope.layout.options.count/$scope.layout.options.lines;
                }else{
                    if($scope.layout.container.width < 600){
                        if($scope.layout.container.width < 400){
                            if($scope.layout.options.count > 2){
                                $scope.layout.options.lines = $scope.layout.options.count;
                                $scope.layout.options.itemsInline = $scope.layout.options.count/$scope.layout.options.lines;
                            }else{
                                $scope.layout.options.lines = 1;
                                $scope.layout.options.itemsInline = $scope.layout.options.count/$scope.layout.options.lines;
                            }
                        }else{
                            if($scope.layout.options.count == 4 || $scope.layout.options.count == 6 || $scope.layout.options.count == 8){
                                $scope.layout.options.lines = 2;
                                $scope.layout.options.itemsInline = $scope.layout.options.count/$scope.layout.options.lines;
                            }else{
                                $scope.layout.options.lines = 1;
                                $scope.layout.options.itemsInline = $scope.layout.options.count/$scope.layout.options.lines;
                            }
                        }
                    }else{
                        $scope.layout.options.lines = 1;
                        $scope.layout.options.itemsInline = $scope.layout.options.count/$scope.layout.options.lines;
                    }
                }

            }
        },
        container:{
            width: document.querySelectorAll('.test-container-inner')[0].offsetWidth,
            height:document.querySelectorAll('.test-container-inner')[0].offsetHeight
        },
        question:{
            type:'quiz',
            hasImage:false,
            contentLength:0,
            height:function(){
                return $scope.layout.container.height/100*40;
            },
            content:{
                fontSize:function(){
                    if($scope.layout.container.width > 600){
                        if($scope.layout.question.contentLength < 200){
                            return 28;
                        }
                        if($scope.layout.question.contentLength < 300){
                            return 24;
                        }
                        if($scope.layout.question.contentLength < 400){
                            return 22;
                        }
                        if($scope.layout.question.contentLength < 500){
                            return 20;
                        }
                        if($scope.layout.question.contentLength < 600){
                            return 18;
                        }
                        if($scope.layout.question.contentLength < 700){
                            return 16;
                        }else{
                            return 14;
                        }
                    }
                    if($scope.layout.container.width  > 300){
                        if($scope.layout.question.contentLength < 200){
                            return 18;
                        }
                        if($scope.layout.question.contentLength < 300){
                            return 16;
                        }
                        if($scope.layout.question.contentLength < 400){
                            return 14;
                        }else{
                            return 14;
                        }
                    }
                    var contentSize = $scope.layout.question.content.innerHeight/$scope.layout.question.height()*100;
                },
                innerHeight:0,
                height:function(){
                    return $scope.layout.question.height();

                },
                width:function(){
                    if($scope.layout.question.hasImage){
                        return $scope.layout.container.width/100*60;
                    }else{
                        return $scope.layout.container.width;
                    }
                },
                left:function(){
                    if($scope.layout.question.hasImage){
                        return $scope.layout.container.width/100*40;
                    }else{
                        return 0;
                    }

                }
            },
            image:{
                left:0,
                width:function(){
                    return $scope.layout.container.width/100*40;
                },
                height:function(){
                    return $scope.layout.question.height();
                }
            }
        },
        options:{
            count:4,
            lines:1,
            itemsInline:4,
            hasImage:false,
            maxLength:0,
            height:function(){
                return $scope.layout.container.height/100*60-($scope.layout.question.type == 'multiquiz' ? ($scope.layout.container.width > 600 ? 70 : 45 ) : 0);
            },
            width:0,
            option:{
                fontSize:function(index){
                    if($scope.layout.options.lines == $scope.layout.options.count){
                        if($scope.layout.options.height() < 400){
                            return 12;
                        }
                        if($scope.layout.options.height() < 300){
                            return 11;
                        }

                        return 14;
                    }else{
                        if($scope.layout.options.option.width() > 260){
                            if($scope.layout.options.maxLength < 20){
                                return 28;
                            }
                            if($scope.layout.options.maxLength < 40){
                                return 24;
                            }
                            if($scope.layout.options.maxLength < 60){
                                return 22;
                            }
                            if($scope.layout.options.maxLength < 80){
                                return 20;
                            }
                            if($scope.layout.options.maxLength < 120){
                                return 18;
                            }
                            if($scope.layout.options.maxLength < 160){
                                return 16;
                            }
                        }
                        if($scope.layout.options.option.width() > 180){
                            if($scope.layout.options.maxLength < 20){
                                return 22;
                            }
                            if($scope.layout.options.maxLength < 40){
                                return 20;
                            }
                            if($scope.layout.options.maxLength < 60){
                                return 18;
                            }
                            if($scope.layout.options.maxLength < 80){
                                return 16;
                            }
                            if($scope.layout.options.maxLength < 120){
                                return 14;
                            }
                        }
                    }
                    //return 14;
                },
                innerHeight:function(index){

                    return document.querySelectorAll('.question-option-inner-content')[index].offsetHeight

                    //return $scope.layout.options.height()/$scope.layout.options.lines;
                },
                height:function(index){
                    return $scope.layout.options.height()/$scope.layout.options.lines;
                },
                width:function(index){
                    return $scope.layout.options.width/$scope.layout.options.itemsInline;
                },
                top:function(index){
                    if($scope.layout.options.lines > 1){
                        if($scope.layout.options.count%$scope.layout.options.itemsInline == 0){
                            if(index < $scope.layout.options.itemsInline){
                                return 0;
                            }else{
                                return parseInt(Math.floor((index)/$scope.layout.options.itemsInline)*$scope.layout.options.option.height(index));
                            }
                        }else{
                            return parseInt(index*$scope.layout.options.option.height(index));
                        }
                    }else{
                        return 0;
                    }
                },
                left:function(index){
                    if($scope.layout.options.lines > 1){
                        return(index+$scope.layout.options.itemsInline)%$scope.layout.options.itemsInline*$scope.layout.options.option.width(index);
                    }else{
                        return index*$scope.layout.options.option.width(index);
                    }
                }
            }
        }
    };

    $scope.test = {
        active:0,
        activeNumber:1,
        question:false,
        correct_options:false,
        questions:[],
        answers:[],
        scene:1,
        theme:'covid',
        document:[],
        progressBar:0,
        progressTimer:0,
        sound:{wrong:{},success:{}},
        time:0,
        soundMode:1,
        font:'default',
        session:[],
        randomList:function(array){
          var m = array.length, t, i;
          // While there remain elements to shuffle
          while (m) {
            // Pick a remaining elementвЂ¦
            i = Math.floor(Math.random() * m--);

            // And swap it with the current element.
            t = array[m];
            array[m] = array[i];
            array[i] = t;
          }

          return array;
        },
        next:function(){
            //if($scope.test.settings.show_answer == 1){
                  $scope.test.scene = 2;
            //}
            $scope.test.progressIndicatorStart(2000);
            $timeout(function(){
                var index = $scope.test.questions.map(function(x) {return x.id; }).indexOf($scope.test.active);
                //console.log(index);
            //    console.log(index);
                if($scope.test.questions[index+1]){
                    $scope.test.activeNumber = index+2;
                    $scope.test.session.answers++;
                    $scope.test.scene = 1;
                    $scope.test.active = $scope.test.questions[index+1].id;
                    $scope.test.question = $scope.test.questions[index+1];
                    $timeout(function(){
                        $scope.layout.resize();
                    },100);
                    $scope.layout.resize();
                    //$scope.test.question.options = $scope.test.randomList($scope.test.question.options);
                }else{
                    $scope.test.endSession();
                    //this.active = this.questions[0].id;
                }
            },2000);
            $scope.layout.resize();
        },
        progressIndicatorStart:function(amount){
            $scope.test.progressBar = 0;
            $scope.test.progressTimer = 0;
            var updateProgress = $interval(function(){
                $scope.test.progressTimer = $scope.test.progressTimer+200;
                $scope.test.progressBar = Math.round($scope.test.progressTimer/amount*100+2);
                if($scope.test.progressBar >= 100){
                    $interval.cancel(updateProgress);
                    $scope.test.progressBar = 0;
                    $scope.test.progressTimer = 0;
                }
            }, 200);

        },
        progressIndicatorStop:function(amount){
            $interval.cancel(updateProgress);
        },
        timer:function(){

            var duration = $scope.test.settings.duration*60;
            console.log('duration',duration);
            var session_end_at = $scope.test.session.start_at+duration;
            console.log('end-at',session_end_at);
            $scope.time_left = session_end_at-$scope.test.time;
            var minutes = Math.floor($scope.time_left / 60);
            var seconds = $scope.time_left - minutes * 60;
            $scope.show_timer = (minutes < 10 ? '0'+minutes : minutes)+':'+(seconds < 10 ? '0'+seconds : seconds);
            $interval(function(){
                $scope.time_left--;
                var minutes = Math.floor($scope.time_left / 60);
                var seconds = $scope.time_left - minutes * 60;
                $scope.show_timer = (minutes < 10 ? '0'+minutes : minutes)+':'+(seconds < 10 ? '0'+seconds : seconds);
                console.log($scope.time_left);
                if($scope.time_left <= 0){
                    $scope.show_timer = '00:00';
                    $scope.test.endSession();
                }
            }, 1000);
        },
        getIndex:function(id){
            return this.questions.map(function(x) {return x.id; }).indexOf(id);
        },
        changeQuestion:function(id){
            this.active = id;
        },
        htmlToPlaintext:function(text) {
            return text ? String(text).replace(/<[^>]+>/gm, '') : '';
        },
        isChecked:function(question_id, option_id){
            if(this.answers[question_id] && this.answers[question_id].indexOf(option_id) !== -1){
                return true;
            }
            return false;
        },
        save:function(question_id){
            if($scope.disableSave == false){
                $scope.disableSave = true;
                var question = $scope.test.questions[this.getIndex(question_id)];

                SessionFactory.saveAnswer(this.session.id, question.id, question.answer, question.type, question.point, this.settings).then(function successCallback(response) {
                    $scope.test.correct_options = response.data.correct_options;
                    $scope.test.message = response.data.message;
                    $scope.test.message_scene = response.data.message_scene;
                    $scope.test.message_gif = response.data.message_gif;

                    $scope.test.progressIndicatorStart(3000);
                    if($scope.test.soundMode == 1){
                        $timeout(function(){
                            if(response.data.correct == 0){
                                  if($scope.test.settings.show_answer == 1){
                                        $scope.test.sound.wrong.play();
                                    }
                            }else{
                                 if($scope.test.settings.show_answer == 1){
                                         $scope.test.sound.success.play();
                                 }
                            }
                        },500);
                    }
                    $timeout(function(){
                        $scope.disableSave = false;
                        $scope.test.next();
                        $scope.test.correct_options = false;
                    },2000);

                }, function errorCallback(response) {
                    console.log('error');
                    console.log(response);
                });
                question.answered = true;

                //this.next();
                return true;
            }else{
                return false;
            }
        },
        setAnswer:function(question_id, option_id){
            if($scope.disableSave == false){
                if($scope.test.correct_options){
                    return false;
                }else{
                    var question = $scope.test.question;
                    if(question.answer == undefined){
                        question.answer = [];
                    }else{
                        if(question.type == 'quiz'){
                            question.answer = [];
                        }
                    }
                    var _o_index = question.answer.indexOf(option_id);
                    if( _o_index > -1){
                        question.answer.splice(_o_index, 1);
                    }else{
                        question.answer.push(option_id);
                    }
                    question.answered = false;
                    this.save(question.id, question.answer);
                }
            }
        },
        setMultiAnswer:function(question_id, option_id){
            if($scope.test.correct_options){
                return false;
            }else{
                var question = $scope.test.questions[this.getIndex(question_id)];
                if(question.answer == undefined){
                    question.answer = [];
                }else{
                    if(question.type == 'quiz'){
                        question.answer = [];
                    }
                }
                var _o_index = question.answer.indexOf(option_id);
                if( _o_index > -1){
                    question.answer.splice(_o_index, 1);
                }else{
                    question.answer.push(option_id);
                }
                question.answered = false;
            //    this.save(question.id, question.answer);
            }
        },
        answeredCount:function(){
           var count = 0;

            angular.forEach(this.questions, function(question){
                count += question.answered ? 1 : 0;
            });
            var progressBar = (count == 0 ? 0 : count/this.questions.length*100);
            //console.log(progressBar);
            $scope.progressBar = (progressBar > 100 ? 100 : progressBar);
            return count;
        },
        endSession:function(){
            $scope.test.scene = 3;
            SessionFactory.endSession(this.session.id).then(function successCallback(response) {
                console.log(response.data.session.id);
                //$location.path('/test/complete/'+response.data.session.id);
                $scope.test.scene = 3;
               // $scope.test.progressIndicatorStart(3000);
                $timeout(function(){
                    $window.location.href = '/test/complete/'+response.data.session.uuid;

                },2000);


            }, function errorCallback(response) {
                console.log(response);
            });
        }

    }

    $scope.renderHtml = function(html_code)
    {
        return $sce.trustAsHtml(html_code);
    }
});
app.controller('BuilderCtrl',function ($scope, $location, $ngConfirm,  $window, Notification, BuilderFactory, Upload, $timeout) {
    $scope.uploading = [];
      $scope.CKEditorOptions = {
        language: 'en',
        allowedContent: true,
        entities: false,
        removeButtons:'Strike,Subscript,Superscript,Anchor,Table,HorizontalRule,SpecialChar,PageBreak,Language,copyformatting,"Paste From Word"',
        extraPlugins:'youtube,justify,blockquote',
        toolbarGroups:[
            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ]},
    		{
                name: 'clipboard',
                groups: ['clipboard'],
                //items: ['Paste', 'PasteText', 'PasteFromWord', '-']
            },
             {
                name: 'colors',
            },{
                name: 'paragraph',
                groups: ['list'],
            }
    	],
        removeDialogTabs:'image:advanced;link:advanced',
        removePlugins:'elementspath',
        fillEmptyBlocks:false,
        tabSpaces:0,
        disallowedContent:'script',
        resize_enabled:false,
        title:false,
        forcePasteAsPlainText:true
      };
    $scope.focusedEditorCheck = function(index){
        if($scope.focusedEditor[index]){
            return true;
        }else{
            return false;
        }
    }
    $scope.focusedEditor = [false,false,false];
    $scope.focused = function(editor, range, oldRange, source, index){
        $timeout(function () {
            $scope.focusedEditor[parseInt(editor.theme.options.modules.toolbar.container.getAttribute('data-model-index'))] = editor.theme.quill.hasFocus();
            if(editor.theme.quill.hasFocus() == true){
                $scope.tempEditor = editor;
                $scope.editor = editor.theme.quill;
            }
        },0);
    };


  $scope.uploadMainImage = function(file, errFiles) {
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: 'https://naurok.com.ua/api/test/documents/direct-upload',
                data: {file: file}
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                    $scope.document_image  = $scope.builder.data.documentTemp.image = response.data;
                    $scope.uploadingDocumentImage = false;

                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                    $scope.uploadingDocumentImage = Math.min(100, parseInt(100.0 *
                                             evt.loaded / evt.total));
            });
        }
  }

 $scope.deleteDocumentImage = function(){
     $scope.document_image = $scope.builder.data.documentTemp.image = null;
 }
  $scope.uploadContentImage = function(file, errFiles) {
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: 'https://naurok.com.ua/api/test/questions/direct-upload',
                data: {file: file, document_id:$scope.builder.data.document.id}
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                    $scope.builder.data.question.image  = response.data;
                    $scope.uploadingQuestionImage = false;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                $scope.uploadingQuestionImage = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });
        }
    }


  $scope.uploadOptionImage = function(file, errFiles,index) {
        $scope.uploading[index] = false;
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        $scope.tempIndex = index;

        if (file) {
            $scope.uploading[index] = 1;
            file.upload = Upload.upload({
                url: 'https://naurok.com.ua/api/test/questions/direct-upload',
                data: {file: file, document_id:$scope.builder.data.document.id}
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                    $scope.builder.data.question.options[index].image  = response.data;
                    $scope.builder.data.question.options[index].value = null;
                    $scope.builder.data.question.optionsHasImage = true;
                    $scope.uploading[index] = false;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {

                $scope.uploading[index] = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
                                         /*
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total)); */
            });
        }
    }
    $scope.insertSymbol = function(instance, symbol){
        //var cursor = instance.getLength() -1;
        instance.insertText($scope.cursorIndex, symbol);
        $scope.cursorIndex = $scope.cursorIndex+1;
        $('#editorSymbols').modal('hide');
    }

    $scope.activeSymbolPanel = function(){
        console.log($scope.tempEditor.theme);
        $scope.editor = $scope.tempEditor.theme.quill;
        var range = $scope.editor.getSelection();
        //console.log(range);
        $scope.cursorIndex = range.index;
        $('#editorSymbols').modal('show');
        $('#editorSymbols').on('hidden.bs.modal', function (e) {
           $scope.editor.setSelection($scope.cursorIndex);
           $scope.editor.focus();
       });
    }
     $scope.editorModules = {
        toolbar: {
           container:'.quill-toolbar',
           handlers: {
               'symbol': function(){
                   console.log(this);
                   var range = this.quill.getSelection();
                   $scope.cursorIndex = range.index;
                   $('#editorSymbols').modal('show');
                   $scope.editor = this.quill;
                   $('#editorSymbols').on('hidden.bs.modal', function (e) {
                      $scope.editor.setSelection($scope.cursorIndex);
                      $scope.editor.focus();
                   });
               }
          }
        }
    };





    $scope.editorSymbolActiveTab = 'math';

    $scope.searchForm  = {
        'only_my': false
    };

    $scope.builder = {
        scene: 1,
        is_new:1,
        active:0,
        documentTotalPoints:0,
        types:[],
        grades:[],
        subjects:[],
        data:{
            document:{
                author:'',
                grade_id:1,
                subject_id:1,
                name:'',
                description:'',
                mark_type:1,
                question_order:0,
                option_order:0,
                time_limit:0,
                duration:10,
                display_all_questions:1,
                display_errors:1,
                activity_card:1,
                activity_pare:1,
                activoty_test:1,
                enable_cloning: 0
            },
            documentTemp:{
                author:'',
                grade_id:1,
                subject_id:1,
                name:'',
                description:'',
                mark_type:1,
                question_order:0,
                option_order:0,
                time_limit:0,
                duration:10,
                display_all_questions:1,
                display_errors:1,
                activity_card:1,
                activity_pare:1,
                activoty_test:1,
                enable_cloning: 1
            },
            original_question:{},
            question:{
                id:false,
                document_id:0,
                is_new:1,
                index:0,
                content:'',
                type:'quiz',
                point:5,
                hint:0,
                hint_penalty:2,
                hint_description:'',
                order:1,
                optionsHasImage: false,
                options:[{correct:0,value:''},{correct:0,value:''},{correct:0,value:''}],

            },
            errors:{
                options:'',
                content:''
            },
            questions:[],
            saved:true,
        },
        onlyImageOption:function(question){
             var found = question.options.some(function (el) {
                return el.image != null;
              });
              if(found){
                  return true;
              }else{
                  return false;
              }
        },
        comboImageOption:function(question){
             var found = question.options.some(function (el) {
                return el.image != null;
              });
              if(found){
                  return true;
              }else{
                  return false;
              }
        },
        getType:function(id){
            var result = $scope.builder.types.filter(obj => {
              return obj.id === id
            })
            return result;
        },
        getSubject:function(id){
        //    console.log(this.subjects);
            var result = this.subjects.filter(function(e) {
              return e.id == id;
            });
            return result[0];
        },
        getGrade:function(id){
            var result = this.grades.filter(function(e) {
              return e.id == id;
            });
            return result[0];
        },
        addOption:function(){
            if(this.data.question.options){
                this.data.question.options.push({correct:0,value:''});
            }else{
                this.data.question.options = [{correct:0,value:''}];
            }
        },
        deleteOption:function(index){
            this.data.question.options.splice( index, 1 );
        },
        deleteOptionImage:function($index){
            BuilderFactory.deleteQuestionImage(this.data.document.id, this.data.question.options[$index].image).then(function successCallback(response) {
                $scope.builder.data.question.options[$index].image = null;
            });
        },
        deleteQuestionImage:function($index){
            BuilderFactory.deleteQuestionImage(this.data.document.id, this.data.question.image).then(function successCallback(response) {
                $scope.builder.data.question.image = null;
                $scope.uploadingQuestionImage = false;
            });
        },
        correctRadio:function(index){
            for(i=0; i<this.data.question.options.length; i++){
                this.data.question.options[i].correct = 0;
            }
            this.data.question.options[index].correct = 1;
        },
        correctCheckbox:function(index){
            if(this.data.question.options[index].correct == 1){
                this.data.question.options[index].correct = 0;
            }else{
                this.data.question.options[index].correct = 1;
            }
        },
        cleanCorrect:function(){
            if(this.data.question.type == 'quiz' || this.data.question.type == 'multiquiz'){
                for(i=0; i<this.data.question.options.length; i++){
                    this.data.question.options[i].correct = 0;
                }
            }
            if(this.data.question.type == 3){
                for(i=0; i<this.data.question.options.length; i++){
                    this.data.question.options[i].correct = 1;
                }
            }
        },
        copyQuestion:function(question){
            this.data.question = angular.copy(question);
            this.data.question.id = null;
            for(i=0; i<this.data.question.options.length; i++){
                this.data.question.options[i].id = null;
            }
            //this.data.original_question = angular.copy(this.data.questions[index]);
        //    this.active = index;
            this.scene = 2;
        },
        editQuestion:function(index){
            //$scope.focusedEditor = false;
            this.data.question = this.data.questions[index];
            this.data.question.point = parseInt(this.data.question.point);
            //this.data.question = angular.copy(question);
            //this.data.original_question = angular.copy(this.data.questions[index]);
            this.active = index;
            this.scene = 2;

        },
        deleteContentImage: function(){
            this.data.question.image = null;
            $scope.uploadingQuestionImage = false;
        },


        newQuestion:function(index){
            $( "body" ).scrollTop( 300 );
            this.scene = 2;
            this.data.question = {
                id:false,
                content:'',
                type:'quiz',
                point:5,
                hint:0,
                hint_penalty:2,
                hint_description:'',
                order:1,
                options:[{correct:0,value:''},{correct:0,value:''},{correct:0,value:''},{correct:0,value:''}]
            };
            //this.data.questions.push(this.data.question);
            //this.data.question = this.data.questions.slice(-1)[0];
            //this.active = this.data.questions.length-1;
        },
        showSearchBlock:function(){
            $scope.showSearchTab = true;
            $scope.searchForm.q = $scope.builder.data.document.name;
            $scope.builder.processSearchForm($scope.searchForm.q);
        },
        createQuestion:function(){
            this.cleanErrors();
            $scope.builder.data.action_loading = true;
            $scope.builder.data.errors = {};
            BuilderFactory.createQuestion(this.data.document.id, this.data.question).then(function successCallback(response) {
                console.log((response.data));
                $scope.builder.data.question = response.data;
                $scope.builder.data.original_question = angular.copy(response.data);
                //$scope.builder.data.questions.splice(-1,1);
                $scope.builder.data.questions.push(response.data);
                $scope.builder.data.saved = true;
                //  Notification.success('Р’РѕРїСЂРѕСЃ СЃРѕС…СЂР°РЅРµРЅ');
                $scope.builder.data.action_loading = false;
                $scope.builder.scene = 1;
                $scope.builder.getDocumentTotalPoints();
                //$scope.builder.data.questions.push(response.data);
            }, function errorCallback(response) {
                $scope.builder.validation(response.data);
                $scope.builder.data.action_loading = false;
                //Notification.error(response.data[0].message);
                if(response.data[0].field == 'options'){
                    $scope.builder.data.errors.options = response.data[0].message;
                }
                if(response.data[0].field == 'content'){
                    $scope.builder.data.errors.content = response.data[0].message;
                }
            //    $scope.builder.validation(response.data);

            //    Notification.error(response.data[0].message);
            });
        },
        updateQuestion:function(){
            this.cleanErrors();
            $scope.builder.data.action_loading = true;
            BuilderFactory.updateQuestion(this.data.document.id, this.data.question.id, this.data.question).then(function successCallback(response) {
                console.log(response.data);
                $scope.builder.data.question = response.data;
                $scope.builder.data.original_question = angular.copy(response.data);
                $scope.builder.data.questions[$scope.builder.active] = response.data;
                $scope.builder.data.saved = true;
                $scope.builder.data.action_loading = false;
                //Notification.success('РџРёС‚Р°РЅРЅСЏ Р·Р±РµСЂРµР¶РµРЅРѕ');
                $scope.builder.scene = 1;
                $scope.builder.getDocumentTotalPoints();
                //$scope.builder.questions.push(response.data);
            }, function errorCallback(response) {
                $scope.builder.validation(response.data);
                //Notification.error(response.data[0].message);
                $scope.builder.data.errors.options = response.data[0].message;
                $scope.builder.data.action_loading = false;
            });
        },
        deleteQuestion:function(question){
            if(question.id){
                //$('.question'+question.id).hide(300);
                var question_id = question.id;
                //$scope.builder.questions.push(response.data);
                var index = this.data.questions.map(function(el) {
                  return el.id;
                }).indexOf(question_id);
                this.data.questions.splice( index, 1 );
                $scope.builder.getDocumentTotalPoints();
                if(question.id){
                    BuilderFactory.deleteQuestion(question.id).then(function successCallback(response) {

                    }, function errorCallback(response) {
                        console.log(response)
                    });
                }
            }
        },
        createDocument:function(){
            $scope.builder.data.action_loading = true;
            BuilderFactory.createDocument(this.data.document).then(function successCallback(response) {
                console.log(response.data);
                $scope.builder.data.document = response.data;
                Notification.success('РРЅС„РѕРјСЂР°С†РёСЏ Рё С‚РµСЃС‚Рµ СЃРѕС…СЂР°РЅРµРЅР°');
                $scope.builder.is_new = 0;
            //    $scope.builder.scene = 2;

                $window.scrollTo(0, 0);
                //$location.path('/test/update').search({'id': response.data.id});
            }, function errorCallback(response) {
                console.log(response)
            });
        },
        updateDocument:function(){
            $scope.builder.data.action_loading = true;
            BuilderFactory.updateDocument(this.data.document.id, this.data.documentTemp).then(function successCallback(response) {
                console.log(response.data);
                $scope.builder.data.document = response.data;
                $scope.builder.data.action_loading = false;
            //    Notification.success('РРЅС„РѕРјСЂР°С†РёСЏ Рё С‚РµСЃС‚Рµ СЃРѕС…СЂР°РЅРµРЅР°');
                $scope.builder.scene = 1;
            }, function errorCallback(response) {
                console.log(response)
            });
        },
        publishDocument:function(){
            $scope.builder.data.action_loading = true;
            this.data.document.status = 2;
            BuilderFactory.updateDocument(this.data.document.id, this.data.document).then(function successCallback(response) {
                console.log(response.data);
                $scope.builder.data.document = response.data;
                $window.location.href = '/test/'+response.data.slug+'.html';
                //Notification.success('РРЅС„РѕРјСЂР°С†РёСЏ Рё С‚РµСЃС‚Рµ СЃРѕС…СЂР°РЅРµРЅР°');
                //$scope.builder.is_new = 0;
                //
                //$window.scrollTo(0, 0);
            }, function errorCallback(response) {
                console.log(response)
            });
        },
        editDocument:function(){
            $scope.builder.data.documentTemp = angular.copy($scope.builder.data.document);
            //$('#'+id).modal('show');
        },
        getDocument:function(id){
            BuilderFactory.getDocument(id).then(function successCallback(response) {
                console.log(response.data);
                //$scope.builder.scene = 2;
                    //console.log(response.data.questions.length);
                    $scope.builder.data.document = response.data.document;
                    $scope.builder.data.questions = response.data.questions;
                    $scope.builder.subjects = response.data.subjects
                    $scope.builder.grades = response.data.grades;
                    $scope.builder.types = response.data.types;
                    /*
                    if(response.data.questions.length > 0){
                        $scope.builder.changeQuestion(0);
                    }else{
                        $scope.builder.newQuestion(0);
                    } */
                    $scope.builder.is_new = 0;
                    $scope.builder.getDocumentTotalPoints();

                //$scope.builder.is_new = 0;
                ///$scope.builder.scene = 2;
            }, function errorCallback(response) {
            //    $location.path('/');
                console.log(response)
            });
        },
        getDocumentTotalPoints:function(){
            var points = 0;
            for(var i =0; i< $scope.builder.data.questions.length; i++) {
                if($scope.builder.data.questions[i] && $scope.builder.data.questions[i].point){
                    console.log($scope.builder.data.questions[i].point);
                    points = points + parseInt($scope.builder.data.questions[i].point);
                }
                //
            }
            $scope.builder.documentTotalPoints = points;
            return points;
        },
        validation:function(errors){
            /*
            for(var i=0; i < errors.length; i++){
                var field = errors[i].field
            //    console.log(field);
                if(field == 'options'){
                    $scope.builder.data.errors.options =  errors[i].message;
                }
            } */
        },
        cleanErrors:function(){
            this.data.errors.options = '';
            this.data.errors.content = '';
        },
        equals:function( x, y ) {
              if ( x === y ) return true;
                // if both x and y are null or undefined and exactly the same

              if ( ! ( x instanceof Object ) || ! ( y instanceof Object ) ) return false;
                // if they are not strictly equal, they both need to be Objects

              if ( x.constructor !== y.constructor ) return false;
                // they must have the exact same prototype chain, the closest we can do is
                // test there constructor.

              for ( var p in x ) {
                if ( ! x.hasOwnProperty( p ) ) continue;
                  // other properties were tested using x.constructor === y.constructor

                if ( ! y.hasOwnProperty( p ) ) return false;
                  // allows to compare x[ p ] and y[ p ] when set to undefined

                if ( x[ p ] === y[ p ] ) continue;
                  // if they have the same strict value or identity then they are equal

                if ( typeof( x[ p ] ) !== "object" ) return false;
                  // Numbers, Strings, Functions, Booleans must be strictly equal

                if ( ! $scope.builder.equals( x[ p ],  y[ p ] ) ) return false;
                  // Objects and Arrays must be tested recursively
              }

              for ( p in y ) {
                if ( y.hasOwnProperty( p ) && ! x.hasOwnProperty( p ) ) return false;
                  // allows x[ p ] to be set to undefined
              }
              return true;
        },
        htmlToPlaintext:function(text) {
            return text ? String(text).replace(/<[^>]+>/gm, '') : '';
        },
        processSearchForm: function(query){
             $scope.searchLoader = true;

            BuilderFactory.searchQuestion(query, $scope.searchForm.only_my ? $scope.searchForm.only_my : false).then(function (response) {
                  $scope.searchLoader = false;
                  $scope.searchedDocuments = response.data;
                  $scope.activeSearchedDocument = $scope.searchedDocuments[0];
                  console.log(response.data);
            });
        },
        setActiveSearchedDocument: function(index){
             $scope.activeSearchedDocument = $scope.searchedDocuments[index];
        },
        cloneQuestion: function(question_id){
             BuilderFactory.cloneQuestion(question_id, this.data.document.id).then(function (response) {
                  //  $scope.searchedDocuments = response.data;
                    //$scope.activeSearchedDocument = $scope.searchedDocuments[0];
                   // console.log((response.data));
                    if(response.data){
                          $scope.builder.data.question = response.data;
                          $scope.builder.data.original_question = angular.copy(response.data);
                          //$scope.builder.data.questions.splice(-1,1);
                          $scope.builder.data.questions.push(response.data);
                          $scope.builder.data.saved = true;
                          //  Notification.success('Р’РѕРїСЂРѕСЃ СЃРѕС…СЂР°РЅРµРЅ');
                          $scope.builder.data.action_loading = false;
                          $scope.builder.scene = 1;
                          $scope.builder.getDocumentTotalPoints();
                          //var $target =
                          $('html,body').animate({scrollTop: $('html,body').height()}, 1000);
                    }
                  console.log(response.data);
             });
       }
    }
    $scope.init = function(document_id){
        if(document_id){
            $scope.builder.getDocument(document_id);
        }

    }

})
app.constant('NG_QUILL_CONFIG', {
  formats: [
    'bold','underline','italic','script'
  ],
  theme: 'snow',
  readOnly: false,
 // clipboard: {
    //  matchVisual: false // https://quilljs.com/docs/modules/clipboard/#matchvisual
  //},
  bounds: document.body
})
app.config([
  'ngQuillConfigProvider',
  'NG_QUILL_CONFIG',
  function (ngQuillConfigProvider, NG_QUILL_CONFIG) {
    ngQuillConfigProvider.set(NG_QUILL_CONFIG)
  }

])


document.addEventListener('text-change', function(){
    console.log('active');
});
/*
quill.on('text-change', function(delta, oldDelta, source) {
  if (source == 'api') {
    console.log("An API call triggered this change.");
  } else if (source == 'user') {
    console.log("A user action triggered this change.");
  }
}); */

app.factory('SessionFactory', function ($http) {
    var getSession = function (id) {
        //return data;
        return $http({
            method: 'GET',
            url: 'https://naurok.com.ua/api2/test/sessions/'+id
        })
    }
    var endSession = function (id) {
        //return data;
        return $http({
            method: 'PUT',
            url: 'https://naurok.com.ua/api2/test/sessions/end/'+id
        })
    }
    var saveAnswer = function (session_id, question_id, answer, type, point,settings) {
        //return data;
        var data = {
            session_id:session_id,
            answer:answer,
            question_id:question_id,
            show_answer:settings.show_answer,
            type:type,
            point:point,
            homeworkType:(settings.type ? settings.type : false),
            homework:(settings.id ? true : false)
        };

        return $http({
            method: 'PUT',
            url: 'https://naurok.com.ua/api2/test/responses/answer',
            data: data
        })
    }

    var getCards = function(id,uuid){
        //return data;
        return $http({
            method: 'POST',
            url: 'https://naurok.com.ua/api/test/documents/'+id+'/flashcard',
            data: {
                'uuid':uuid
            }
        })
    }

    var getMatch = function(id, uuid){
        //return data;
        return $http({
            method: 'POST',
            url: 'https://naurok.com.ua/api/test/documents/'+id+'/match',
            data: {
                'uuid':uuid
            }
        })
    }
    var updateMatch = function (id, uuid, score) {
        return $http({
            method: 'POST',
            url: 'https://naurok.com.ua/api/test/documents/'+id+'/match-update',
            data: {
                'document_id': id,
                'score':score,
                'uuid':uuid
            }
        })
    }
    return {
        getCards: getCards,
        getSession: getSession,
        endSession: endSession,
        saveAnswer: saveAnswer,
        getMatch: getMatch,
        updateMatch: updateMatch
    }
});



app.controller('CardCtrl', function ($scope, $interval, SessionFactory,  Notification, $hotkey, $sce) {

    $scope.init = function(document_id, uuid){
        cards.document_id = document_id;
        cards.uuid = uuid;
        cards.getCards();


    }

    $scope.cards = cards =
    {
        active:1,
        variant:1,
        side:1,
        uuid:null,
        items:[],
        getCards: function(){
                    SessionFactory.getCards(cards.document_id, cards.uuid).then(function successCallback(response) {
                        //console.log(response.data.items);
                        if (response.data.result) {
                            cards.items = response.data.cards;
                            console.log(cards.items);
                            $scope.domReady = 1;

                        } else {
                            Notification.error(response.data.message);
                        }
                    }, function errorCallback(response) {
                        console.log(response)
                    });
        },
        right:function(){
                if(cards.active == cards.items.length){
                    cards.active = 1;
                }else{
                    cards.active = cards.active+1;
                }
            //    angular.element('.card-item-block'+cards.active).addClass('animated slideInRight');
            angular.element(document.querySelector('.flip-card')).removeClass('flipped');
            cards.side = 1;
        },
        left:function(){
            if(cards.active == 1){
                cards.active = cards.items.length;
            }else{
                cards.active = cards.active-1;
            }
            //angular.element('.card-item-block'+cards.active).addClass('animated slideInLeft');
            angular.element(document.querySelector('.flip-card')).removeClass('flipped');
            cards.side = 1;
        },
        flip:function(){
            cards.side = (cards.side == 1 ? 2 : 1);
            if(cards.side == 1){
                angular.element(document.querySelector('.card-item-block'+cards.active+' .flip-card')).removeClass('flipped');
            }else{
                angular.element(document.querySelector('.card-item-block'+cards.active+' .flip-card')).addClass('flipped');
            }
        }
    }
    $hotkey.bind('Right', function(event) {
        cards.right();
    });
    $hotkey.bind('Left', function(event) {
        cards.left();
    });

    $hotkey.bind('D', function(event) {
        alert('Р’ Р·Р°РєР»Р°РґРєРё');
    });
    $hotkey.bind('Enter', function(event) {
        cards.flip();
    });


    $scope.hideHelpBlock = function(){
        //var cardHelpHide = localStorage.getItem('cardHelpHide');
        localStorage.setItem('cardHelpHide', 1);
        $scope.hide_help_block = 1;
    }
    $scope.doSomething = function(){
                  $scope.cards.active = 2;
                  $scope.cards.variant = 1;
    }
    $scope.callFunction = function(eventNew) {
      if (eventNew.which==39)
        alert('Right arrow key pressed');
    }
    $scope.renderHtml = function(html_code)
    {
        return $sce.trustAsHtml(html_code);
    }
});



app.controller('PairCtrl', function ($scope, $interval, $window, $timeout, SessionFactory,  Notification, $sce) {
    $scope.matrix = matrix = [];
    $scope.init = function(document_id, uuid){
        game.document_id = document_id;
        console.log(uuid);
        $scope.game.uuid = uuid;
        //$scope.containerwidth = document.querySelectorAll('.test-container-inner')[0].offsetWidth;
        //$scope.layout.container.height = document.querySelectorAll('.test-container-inner')[0].offsetHeight;
        game.getItems();
        $scope.actHeight = window.innerHeight;
    }
    $scope.game = game = {
        items:[],
        document_id:null,
        uuid:null,
        scene:1,
        personal:false,
        rating:null,
        netWidth:0,
        matchFirst:null,
        matchSecond:null,
        netHeight:0,
        zoneSie:2,
        message:{
            final:''
        },
        start:function(){
            $scope.tryResize();
            game.scene = 2;
            game.timer.start();
            //angular.element('.draggable').removeClass('pair-act__block--checking');
        },
        stop:function(){
            $scope.game.scene = 3;
            game.getItems();
        },
        matchPair:function(item, index){
             if($scope.game.matchFirstIndex == null){
                   $scope.game.matchFirstItem = item;
                   $scope.game.matchFirstIndex = index;
                   angular.element('.item'+$scope.game.matchFirstIndex).removeClass('animated').removeClass('shake');
             }else{
                   if($scope.game.matchSecondIndex == null){
                        $scope.game.matchSecondItem = item;
                        $scope.game.matchSecondIndex = index;
                        angular.element('.item'+$scope.game.matchSecondIndex).removeClass('animated').removeClass('shake');
                        if($scope.game.matchSecondItem.id == $scope.game.matchFirstItem.id && +$scope.game.matchFirstIndex != $scope.game.matchSecondIndex){
                              angular.element('.item'+$scope.game.matchFirstIndex).addClass('animated zoomOut').removeClass('item').removeClass('item'+$scope.game.matchFirstIndex);
                              angular.element('.item'+$scope.game.matchSecondIndex).addClass('animated zoomOut').removeClass('item').removeClass('item'+$scope.game.matchSecondIndex);
                              $timeout(function(){
                                    $scope.game.matchFirstIndex = null;
                                    $scope.game.matchSecondIndex = null;
                                    game.check();
                              },100);
                        }else{
                              angular.element('.item'+$scope.game.matchFirstIndex).addClass('animated shake');
                              angular.element('.item'+$scope.game.matchSecondIndex).addClass('animated shake');
                              $timeout(function(){
                                    angular.element('.item').removeClass('animated').removeClass('shake');
                                    angular.element('.item').removeClass('animated').removeClass('shake');
                                    $scope.game.matchFirstIndex = null;
                                    $scope.game.matchSecondIndex = null;
                              },300);
                        }
                   }else{
                        $scope.game.matchFirstIndex = null;
                        $scope.game.matchSecondIndex = null;
                   }

             }
        },
        setPositionPC:function(){
             $scope.game.zoneSize = size = 4;
             zoneWidth = Math.round($scope.game.netWidth/size);
             zoneHeight = Math.round($scope.game.netHeight/size);
             for(var y=1; y<= size; y++){
                  for(var x=1; x<= size; x++){
                        $scope.matrix.push({'maxHeight':y*zoneHeight,'maxWidth':x*zoneWidth,'minHeight':(y-1)*zoneHeight,'minWidth':(x-1)*zoneWidth});
                   }
             }
             $timeout(function(){
                  $scope.game.items = $scope.game.items.map(function(item, index){
                      var itemInZone = Math.round($scope.game.items.length/($scope.game.zoneSize*$scope.game.zoneSize));
                      var zone = Math.round(index/itemInZone);
                      if($scope.matrix[zone] == undefined)
                        var zone = 0;

                      var divWidth = document.querySelectorAll('.elem'+item.id)[0].offsetWidth;
                      var divHeight = document.querySelectorAll('.elem'+item.id)[0].offsetHeight;
                      var posx = (Math.random() * ($scope.matrix[zone].maxWidth - divWidth - $scope.matrix[zone].minWidth) +  $scope.matrix[zone].minWidth).toFixed();
                      var posy = (Math.random() * ($scope.matrix[zone].maxHeight - divHeight - $scope.matrix[zone].minHeight) +  $scope.matrix[zone].minHeight).toFixed();

                      item.left = posx;
                      item.top = posy;
                      item.transform = '0px, 0px';
                      item.x = 0;
                      item.y = 0;
                      return item;
                  });
            },100);
        },
        setPositionMobile:function(){
             sizeW = 4; //($scope.game.items.length < 9 || window.innerWidth < 800 ? 3 : 4);
             sizeH = Math.ceil($scope.game.items.length/sizeW);
             //$scope.game.zoneSize = size = ($scope.game.items.length < 9 || window.innerWidth < 900 ? 3 : 4);
             zoneWidth = Math.round(($scope.game.netWidth-5)/sizeW)-5;
             zoneHeight = Math.round(($scope.game.netHeight-5)/sizeH)-10;
             for(var y=0; y< sizeH; y++){
                  for(var x=0; x< sizeW; x++){
                        $scope.matrix.push({'width':zoneWidth,'height':zoneHeight,'top':y*(zoneHeight+5)+5,'left':x*(zoneWidth+5)+5});
                   }
             }
             $timeout(function(){
                  $scope.game.items = $scope.game.items.map(function(item, index){

                      var coords = $scope.matrix[index];
                     // var divWidth = document.querySelectorAll('.elem'+item.id)[0].offsetWidth;
                     // var divHeight = document.querySelectorAll('.elem'+item.id)[0].offsetHeight;
                     // var posx = (Math.random() * ($scope.matrix[zone].maxWidth - divWidth - $scope.matrix[zone].minWidth) +  $scope.matrix[zone].minWidth).toFixed();
                    //  var posy = (Math.random() * ($scope.matrix[zone].maxHeight - divHeight - $scope.matrix[zone].minHeight) +  $scope.matrix[zone].minHeight).toFixed();

                      item.left = coords.left;
                      item.top = coords.top;
                      item.width = coords.width;
                      item.height = coords.height;
                      item.transform = '0px, 0px';
                      item.x = 0;
                      item.y = 0;
                      return item;
                  });
            },100);
        },
        getItems:function(){
                    SessionFactory.getMatch(game.document_id, $scope.game.uuid).then(function successCallback(response) {
                        //console.log(response.data.items);
                        if (response.data.result) {
                            $scope.game.items = response.data.items;
                            $scope.game.score = response.data.score;
                        } else {
                            Notification.error(response.data.message);
                        }
                    }, function errorCallback(response) {
                        console.log(response)
                    });
        },
        messages:function(){
            console.log(game.score.score, game.timer.counter)
            if(game.score.score > game.timer.counter){
                game.message.final = 'Р’Рё РІСЃС‚Р°РЅРѕРІРёР»Рё РІР»Р°СЃРЅРёР№ СЂРµРєРѕСЂРґ!';
            }else{
                game.message.final = 'РЎРїСЂРѕР±СѓР№С‚Рµ С‰Рµ СЂР°Р·, РјРѕР¶Р»РёРІРѕ, РІРё Р·РјРѕР¶РµС‚Рµ РїРѕРєСЂР°С‰РёС‚Рё РІР»Р°СЃРЅРёР№ СЂРµР·СѓР»СЊС‚Р°С‚!';
            }
            if(game.guest){
                game.message.final = 'Р—Р°СЂРµС”СЃС‚СЂСѓР№С‚РµСЃСЏ, С‰РѕР± Р·Р±РµСЂС–РіР°Р»РёСЃСЏ РІРёС€С– СЂРµР·СѓР»СЊС‚Р°С‚Рё!';
            }
        },
        check:function(){
            console.log(angular.element('.item').length);
            if(angular.element('.item').length == 0){
                game.timer.stop = true;
                $scope.game.scene = 3;
                $scope.loadResults = true;
                //game.getItems();
                //game.scene = 3;
                $scope.game.items = [];
                $scope.init($scope.game.document_id, $scope.game.uuid);
                SessionFactory.updateMatch(game.document_id, $scope.game.uuid, game.timer.counter).then(function successCallback(response) {
                    if (response.data.result) {
                        $scope.loadResults = false;
                        game.rating = response.data.rating;
                        game.personal = response.data.personal;
                        game.personal.position = response.data.position;
                        game.guest = response.data.guest;
                        //game.calculation();
                        game.messages();
                    } else {
                        Notification.error(response.data.message);
                    }
                }, function errorCallback(response) {
                    console.log(response)
                });
            }
        },
        timer:{
            counter:0,
            obj:null,
            start: function(){
                game.timer.counter = 0;
                game.timer.stop = false;
                game.timer.obj = $interval(game.timer.iteration,10);
            },
            iteration: function(){

                if(game.timer.stop == true){
                    $interval.cancel(game.timer.obj);
                }else{
                    game.timer.counter++;
                }
            },
            stop: false,
            seconds:function(ms){
                var s = Math.floor(ms / 100);
                var ms = Math.floor(ms%100);
                //var s = +'.'+Math.floor(ms%100);
                return s+'.'+(ms < 10 ? '0'+ms : ms);
            }
        },
        getRandomInt: function(min, max) {
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }
    }
    $scope.tryResize = function(){
       $scope.actHeight = window.innerHeight;
       $scope.actWidth = window.innerWidth;
      // console.log(window.innerWidth);
       $scope.game.netWidth =  window.innerWidth-16;
       $scope.game.netHeight =  window.innerHeight-58;
       if(window.innerWidth < 800 || window.innerHeight < 500){
            //$scope.game.items.length=8;
            $scope.game.netWidth = $scope.game.netWidth*2;
            //console.log('bad idea, width:'+window.innerWidth+', height:'+window.innerHeight);
            $scope.game.setPositionMobile();
       }else{
             $scope.game.setPositionMobile();
            //$scope.game.setPositionPC();
       }
    }
    angular.element($window).bind('resize', function(){
      $scope.tryResize();
      $scope.$digest();
  });
    $scope.renderHtml = function(html_code)
    {
        return $sce.trustAsHtml(html_code);
    }
});


app.factory('BuilderFactory', function ($http) {

    var getDocument = function (id) {
        //return data;
        return $http({
            method: 'GET',
            url: 'https://naurok.com.ua/api/test/documents/'+id
        })
    }

    var getSession = function (id) {
        //return data;
        return $http({
            method: 'GET',
            url: 'https://naurok.com.ua/api/test/sessions/'+id
        })
    }

    var createDocument = function (data) {
        //return data;
        return $http({
            method: 'POST',
            url: 'https://naurok.com.ua/api/documents',
            data: data
        })
    }
    var updateDocument = function (id, data) {
        //return data;
        return $http({
            method: 'PUT',
            url: 'https://naurok.com.ua/api/test/documents/'+id,
            data: data
        })
    }

    var searchQuestion = function (q, only_my) {
        return $http({
            method: 'GET',
            url: 'https://naurok.com.ua/api/test/questions/search?q='+q+'&only_my='+(only_my*1)
        });
    }
    var cloneQuestion = function (question_id, document_id) {

         var data = {};
         data.id = question_id;
         data.document_id = document_id;
         data._csrf = $('meta[name="csrf-token"]').attr('content');
         return $http({
             method: 'POST',
             url: 'https://naurok.com.ua/api/test/questions/clone',
             data: data
         })
    }
    var createQuestion = function (document_id, data) {
        //return data;
        data.document_id = document_id;
        data._csrf = $('meta[name="csrf-token"]').attr('content');
        return $http({
            method: 'POST',
            url: 'https://naurok.com.ua/api/test/questions?expand=options',
            data: data
        })
    }

    var updateQuestion = function (document_id, id, data) {
        //return data;
        data.document_id = document_id;
        data._csrf = $('meta[name="csrf-token"]').attr('content');
        return $http({
            method: 'PATCH',
            url: 'https://naurok.com.ua/api/test/questions/'+id+'?expand=options',
            data: data
        })
    }
    var deleteQuestion = function (id) {
        //return data;
        var data = {};
        data._csrf = $('meta[name="csrf-token"]').attr('content');
        return $http({
            method: 'DELETE',
            url: 'https://naurok.com.ua/api/test/questions/'+id
        })
    }
    var deleteQuestionImage = function (document_id, file) {
        //return data;
        var data = {};
        data.document_id = document_id;
        data.file = file;
        data._csrf = $('meta[name="csrf-token"]').attr('content');
        return $http({
            method: 'POST',
            url: 'https://naurok.com.ua/api/test/questions/delete-image',
            data: data
        })
    }

    return {
        getDocument: getDocument,
        getSession: getSession,
        createDocument: createDocument,
        updateDocument: updateDocument,
        searchQuestion: searchQuestion,
        cloneQuestion: cloneQuestion,
        createQuestion: createQuestion,
        updateQuestion: updateQuestion,
        deleteQuestion: deleteQuestion,
        deleteQuestionImage: deleteQuestionImage
    }
});
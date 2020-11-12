<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="NaOtvet.WebApi.test" %>

<!DOCTYPE html>
<html lang="uk-UK">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-title" content="На Урок!">
    <meta name="msapplication-TileColor" content="#5362c2">
    <link rel="icon" href="https://naurok.com.ua/favicon.ico" type="image/x-icon"/>
    <link rel="shortcut icon" href="https://naurok.com.ua/favicon.ico" type="image/x-icon"/>
     <link rel="manifest" href="https://naurok.com.ua/manifest_push.json">
    <meta name="csrf-param" content="_csrf">
<meta name="csrf-token" content="ZgCMn59iNEFAn2v8n3G7MyAl8xkYUeoNjjWh5iBWv1o2bvjv8BtTBQzJLo7xFY5rFkusd2A5kEHNRJTWEz3ePg==">

    <title>Тестування</title>
    <meta name="google-site-verification" content="_PAYSIZqXxorQuFLK8-yW4jkm-0L1wmWwzeF7nncqtU" />
    <meta property="fb:app_id" content="589149888143238">
<meta property="og:locale" content="uk_UA">
<link href="https://naurok.com.ua/js/vendor/bower/angular-confirm/dist/angular-confirm.min.css" rel="stylesheet">
<link href="https://naurok.com.ua/js/vendor/bower/angular-ui-notification/dist/angular-ui-notification.min.css" rel="stylesheet">
<link href="https://naurok.com.ua/css/quill.snow.css" rel="stylesheet">
<link href="https://naurok.com.ua/css/quill.bubble.css" rel="stylesheet">
<link href="https://naurok.com.ua/css/site.full.css?v1.26.38" rel="stylesheet">
    <!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-PVX7XW2');</script>
<!-- End Google Tag Manager -->
<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-108352460-3"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'UA-108352460-3', { 'send_page_view': false });
</script>


    <!-- Facebook Pixel Code -->
    <script>
      !function(f,b,e,v,n,t,s)
      {if(f.fbq)return;n=f.fbq=function(){n.callMethod?
      n.callMethod.apply(n,arguments):n.queue.push(arguments)};
      if(!f._fbq)f._fbq=n;n.push=n;n.loaded=!0;n.version='2.0';
      n.queue=[];t=b.createElement(e);t.async=!0;
      t.src=v;s=b.getElementsByTagName(e)[0];
      s.parentNode.insertBefore(t,s)}(window, document,'script',
      'https://connect.facebook.net/en_US/fbevents.js');
      fbq('init', '186487121900322');
      fbq('track', 'PageView');
    </script>
    <noscript><img height="1" width="1" style="display:none"
      src="https://www.facebook.com/tr?id=186487121900322&ev=PageView&noscript=1"
    /></noscript>
    <!-- End Facebook Pixel Code -->
    <script src="https://apis.google.com/js/platform.js" async defer></script>
</head>
<body style="margin:0;">
    <!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-PVX7XW2"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <div class="activity-wrapper">

        <style>
body, html{
    -webkit-touch-callout: none;
    -webkit-user-select: none;
    -khtml-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}
</style>

<div id="ng" runat="server" ng-app="testik" ng-controller="TestCtrl" ng-init="" class="{{test.font}}" oncopy="return false" oncut="return false" onpaste="return false">
        <nav id="w0" class="test-header animated fadeInDown anim-300-duration" style="">
        <div class="container-fluid-test">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <div class="animated fadeInDown" style="color:#fff"  ng-show="test.questions.length > 0" ng-cloak>
                        <div class="numberQuestionsLeft" ng-show="test.questions.length > 0" ng-cloak><span ng-bind="test.session.answers+1" class="currentActiveQuestion">1</span> / <span ng-bind="test.document.questions"></span></div>

                        <a href="javascript:void(0)" data-toggle="tooltip" data-placement="right" title="Вимкнути звук" class="changeSoundTesting off" ng-click="test.soundMode = 0" ng-show="test.questions.length > 0 && test.soundMode == 1 && test.settings.show_answer == 1"><i class="fa fa-volume-up" aria-hidden="true"></i></a>
                        <a href="javascript:void(0)" data-toggle="tooltip" data-placement="right" title="Вімкнути звук" class="changeSoundTesting onn" ng-click="test.soundMode = 1" ng-show="test.questions.length > 0 && test.soundMode == 0 && test.settings.show_answer == 1"><i class="fa fa-volume-off" aria-hidden="true"></i></a>
                                        </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <div class="text-center">
                          <img src="https://naurok.com.ua/img/logo.png" height="40" ng-if="!show_timer">
                          <div class="score  animated fadeInDown" ng-cloak ng-if="show_timer">
                               <div class="score__user-carrent"><span ng-bind="show_timer"></span></div>
                          </div>
                     </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <div class="text-right animated fadeInDown" style="color:#fff"  ng-show="test.questions.length > 0" ng-cloak>
                        <a href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Змінити шрифт" class="changeFontTesting dyslexia" ng-click="test.font = 'dyslexia'" ng-show="test.font == 'default'"><i class="fa fa-font" aria-hidden="true"></i> Дислексія</a>
                        <a href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Змінити шрифт" class="changeFontTesting default" ng-click="test.font = 'default'" ng-show="test.font == 'dyslexia'"><i class="fa fa-font" aria-hidden="true"></i> Звичайний</a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Завершити" class="endSessionButton" ng-click="test.endSession()"><i class="fa fa-times"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </nav>
    <div class="test-container {{test.theme}}">
        <div class="test-screen">
            <div class="test-event-container">
                <div class="test-wrapper  animated fadeInDown">
                    <div ng-show="test.questions.length <= 0">
                        <div class="loader text-center  animated infinite pulse" style="color:#f48617"><i class="fa fa-spinner fa-spin fa-3x fa-fw" style="font-size:90px; position:relative; top:150px;"></i></div>
                    </div>
                    <div class="test-container-inner" ng-show="test.scene == 1">
                        <div class="test-question-content animated zoomIn faster" ng-show="test.question.content" ng-cloak style="width:{{layout.container.width}}px; height:{{layout.question.height()}}px">
                            <div class="test-question-content-inner">
                                <div class="test-content-image"  ng-show="test.question.image" style="width:{{layout.question.image.width()}}px; left:{{layout.question.image.left}}px; height:{{layout.question.image.height()}}px;">
                                    <img ng-show="test.question.image" ng-src="{{test.question.image}}" />
                                </div>
                                <div class="test-content-text" style="width:{{layout.question.content.width()}}px;  left:{{layout.question.content.left()}}px;  height:{{layout.question.content.height()}}px;" ng-class="{'scrolled' : layout.question.content.innerHeight > layout.question.height()-30}">
                                     <div class="test-content-text-inner" style="font-size:{{layout.question.content.fontSize()}}px;" ng-bind-html="renderHtml(test.question.content)"></div>
                                </div>
                            </div>
                        </div>
                        <div class="test-question-options" style="height:{{layout.options.height()}}px">
                            <div class="test-options-grid">
                                <div ng-repeat="v in test.question.options track by $index" class="test-option test-option{{$index}}  animated zoomIn faster" style="
                                            height:{{layout.options.option.height($index)}}px;
                                            width:{{layout.options.option.width($index)}}px;
                                            top:{{layout.options.option.top($index)}}px;
                                            left:{{layout.options.option.left($index)}}px;">
                                    <div ng-if="test.question.type == 'quiz'" class="question-option-inner" ng-click="test.setAnswer(test.question.id,v.id)" ng-class="{'active' : test.question.answer.indexOf(v.id) > -1, 'correct' : test.correct_options[v.id] == 1,  'fail' : test.correct_options[v.id] == 0, 'animated tada': test.question.answer.indexOf(v.id) > -1 && test.correct_options[v.id] == 1, 'scrolled' : layout.options.option.innerHeight($index) > layout.options.option.height($index)-15}">
                                        <div ng-if="v.image" class="question-option-image" ng-style="{'background-image':'url(' + v.image + ')'}"></div>
                                        <div ng-if="v.value" class="question-option-inner-content"  style="font-size:{{layout.options.option.fontSize($index)}}px;" ng-bind-html="renderHtml(v.value)"></div>
                                    </div>
                                    <div ng-if="test.question.type == 'multiquiz'" class="question-option-inner question-option-inner-multiple" ng-click="test.setMultiAnswer(test.question.id,v.id)" ng-class="{'active' : test.question.answer.indexOf(v.id) > -1, 'correct' : test.correct_options[v.id] == 1,  'fail' : test.correct_options[v.id] == 0, 'scrolled' : layout.options.option.innerHeight($index) > layout.options.option.height($index)-15}">
                                        <div ng-cloak class="question-checkbox-state">
                                            <i class="fa fa-square-o" aria-hidden="true"  ng-hide="test.question.answer.indexOf(v.id) > -1"></i>
                                            <i class="fa fa-check-square-o" aria-hidden="true" ng-show="test.question.answer.indexOf(v.id) > -1"></i>
                                        </div>
                                        <div ng-if="v.image" class="question-option-image" ng-style="{'background-image':'url(' + v.image + ')'}"></div>
                                        <div ng-if="v.value" class="question-option-inner-content"  style="font-size:{{layout.options.option.fontSize($index)}}px;" ng-bind-html="renderHtml(v.value)"></div>
                                    </div>

                                </div>

                            </div>
                        </div>
                        <div ng-if="test.question && test.question.type == 'multiquiz' && disableSave == false" ng-cloak>
                            <div class="test-multiquiz-save-line" ng-show="!test.question.answer || test.question.answer.length == 0"><span>Обери варіанти відповідей</span></div>
                            <a href="javascript:void(0)" class="test-multiquiz-save-button" ng-show="test.question.answer &&  test.question.answer.length > 0"  ng-click="test.save(test.question.id, question.answer)"><span>Зберегти відповідь</span></a>
                        </div>
                    </div>
                    <div class="test-container-inner" ng-show="test.scene == 2">
                          <div>
                              <div class="message_scene {{test.message_scene}}" ng-cloak style="width:{{layout.container.width}}px; height:{{layout.container.height}}px;">
                                  <div class="scene-background">
                                        <!--
                                      <div class="hellowin-bg-1  animated slideInDown"></div>
                                      <div class="hellowin-bg-3 animated slideInDown"></div>
                                      <div class="hellowin-bg-2 animated slideInUp"></div> -->
                                      <div class="heading animated slideInDown"><span ng-bind="test.message"></span></div>
                                      <div class="scene-image-container animated slideInUp">
                                         <img ng-if="test.message_scene == 'success'" ng-src="https://naurok.com.ua/img/test/{{test.theme}}/good-{{test.message_gif}}.png"  class="message_scene-image" style="max-height:{{layout.options.height()}}px; max-width:{{layout.container.width}}px;"/>
                                         <img ng-if="test.message_scene == 'failed'" ng-src="https://naurok.com.ua/img/test/{{test.theme}}/fail-{{test.message_gif}}.png"  class="message_scene-image" style="max-height:{{layout.options.height()}}px; max-width:{{layout.container.width}}px;"/>
                                      </div>
                                 <!-- <img src="{{test.message_gif}}" ng-show="test.message_gif" class="test-submit-answer-image" /> -->
                                    </div>
                              </div>
                          </div>
                      </div>
                      <div class="test-container-inner" ng-show="test.scene == 3">
                          <div >
                              <div class="message_scene ended"  ng-cloak style="width:{{layout.container.width}}px; height:{{layout.container.height}}px"> <!-- style="width:{{layout.container.width}}px; height:{{layout.container.height}}px" -->
                                   <div class="scene-background">
                                      <!-- <div class="hellowin-bg-1 animated slideInDown"></div>
                                     <div class="hellowin-bg-3 animated slideInDown"></div>
                                     <div class="hellowin-bg-2 animated slideInUp"></div> -->
                                       <div class="heading animated slideInDown" style="top:{{layout.question.height()-150}}px"><span>Тест завершено</span></div>
                                    </div>
                              </div>
                          </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</div>
      <!--/ footer.footer-->
    </div>
<script src="https://kit.fontawesome.com/2b47558e31.js" crossorigin="anonymous"></script>
<script src="https://naurok.com.ua/assets/1c60ebce/jquery.js"></script>
<script src="https://naurok.com.ua/assets/c41ce55f/yii.js"></script>
<script src="https://naurok.com.ua/js/app_core.js?4.1"></script>
<script src="https://naurok.com.ua/js/bootstrap.min.js"></script>
<script src="https://naurok.com.ua/js/lib/ckeditor/ckeditor.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.7.8/angular-sanitize.min.js"></script>
<script src="https://naurok.com.ua/js/vendor/bower/angular-confirm/dist/angular-confirm.min.js"></script>
<script src="https://naurok.com.ua/js/vendor/bower/angular-ui-notification/dist/angular-ui-notification.min.js"></script>
<script src="https://naurok.com.ua/js/vendor/bower/angular-ckeditor/angular-ckeditor.min.js"></script>
<script src="https://naurok.com.ua/js/quill.min.js"></script>
<script src="https://naurok.com.ua/js/ng-quill.js"></script>
<script src="https://naurok.com.ua/js/lib/file/ng-file-upload-shim.min.js"></script>
<script src="https://naurok.com.ua/js/lib/file/ng-file-upload.min.js"></script>
<script src="https://naurok.com.ua/js/lib/hotkey.js"></script>
<script src="https://naurok.com.ua/js/lib/interact.min.js"></script>
<script src="https://naurok.com.ua/js/lib/ng-websocket2.js?2"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/socket.io/2.3.0/socket.io.js"></script>
<script src="https://naurok.com.ua/js/lib/socket.min.js?2"></script>
<script src="https://naurok.com.ua/js/lib/howler.min.js"></script>
<script src="naurok_assets/js/app_test.test.js"></script>
<script src="https://naurok.com.ua/js/app.js"></script>
<script src="https://naurok.com.ua/js/share.js"></script>
<script src="https://naurok.com.ua/js/script.js?v2.2.96"></script>
<script src="https://naurok.com.ua/js/lightbox.js"></script>
<script src="https://naurok.com.ua/js/jquery.history.min.js"></script>
<script src="https://naurok.com.ua/js/jquery.pin.min.js"></script>
<script src="https://naurok.com.ua/js/katex.js"></script>
<script src="https://naurok.com.ua/js/base64.js"></script>
<script src="https://naurok.com.ua/js/content.js"></script>
<script src="https://naurok.com.ua/js/headline.js"></script>
<script src="https://naurok.com.ua/js/student.js"></script>
<script src="https://naurok.com.ua/js/nps.js"></script>
<script src="https://naurok.com.ua/js/slick.min.js"></script></html>


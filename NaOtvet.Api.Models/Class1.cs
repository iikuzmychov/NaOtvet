using System;

namespace NaOtvet
{
    [Serializable]
    public class Class1
    {
        private string url;
        private string description;

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException();

                url = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException();

                description = value;
            }
        }

        public Class1(string url, string description)
        {
            Url = url;
            Description = description;
        }

        public Class1() : this(string.Empty, string.Empty) { }
    }
}

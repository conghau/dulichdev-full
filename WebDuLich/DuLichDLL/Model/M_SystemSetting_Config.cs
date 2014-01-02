using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuLichDLL.Model
{
    public enum SystemSettingAttri
    {
        PATH_IMAGE_CITY,
        PATH_IMAGE_PLACE,
        AVATAR_DEFAULT,
        PATH_AVATAR_CITY,
    }

    public class M_SystemSetting_Config
    {
        #region CONSTRUCTORS
        public M_SystemSetting_Config()
        {

        }

        #endregion

        #region  ATTRIBUTE

        private string _PATH_IMAGE_CITY;


        private string _PATH_IMAGE_PLACE;


        private string _AVATAR_DEFAULT;


        private string _PATH_AVATAR_CITY;



        #endregion

        #region PROPERTIES
        public string PATH_IMAGE_CITY
        {
            get { return _PATH_IMAGE_CITY; }
            set { _PATH_IMAGE_CITY = value; }
        }

        public string PATH_IMAGE_PLACE
        {
            get { return _PATH_IMAGE_PLACE; }
            set { _PATH_IMAGE_PLACE = value; }
        }

        public string AVATAR_DEFAULT
        {
            get { return _AVATAR_DEFAULT; }
            set { _AVATAR_DEFAULT = value; }
        }

        public string PATH_AVATAR_CITY
        {
            get { return _PATH_AVATAR_CITY; }
            set { _PATH_AVATAR_CITY = value; }
        }
        #endregion
    }
}

namespace ERPMedicalCenter
{
    public class BaseEntity
    {

        #region Table Fields

        int _ID;
      
        #endregion

        #region Public Properties

        /// <summary>
        /// The ID of the record.
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


      

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes all members with the defualt values.
        /// </summary>
        public BaseEntity()
        {
            _ID = 0;
           
        }
        /// <summary>
        /// Initializes all members with the supplied values.
        /// </summary>
        /// <param name="iID">The ID of the record to load its values to the class memebrs.</param>
        public BaseEntity(int iID)
        {
            _ID = iID;
           
        }
        public BaseEntity(int iID, int iUserID)
        {
            _ID = iID;
           
        }

        #endregion

        #region Private Methos

        /// <summary>
        /// Set the defualt values of the class members
        /// </summary>
        protected virtual void SetDefaults()
        {
            _ID = 0;
           
        }

        #endregion

    }
}
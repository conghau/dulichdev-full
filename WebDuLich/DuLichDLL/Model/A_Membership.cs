using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_Membership
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long? _a_UserProfileID;
        public long? A_UserProfileID
        {
            get { return _a_UserProfileID; }
            set { _a_UserProfileID = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private int _passwordFailuresSinceLastSuccess;
        public int PasswordFailuresSinceLastSuccess
        {
            get { return _passwordFailuresSinceLastSuccess; }
            set { _passwordFailuresSinceLastSuccess = value; }
        }
        private bool _isBlocked;
        public bool IsBlocked
        {
            get { return _isBlocked; }
            set { _isBlocked = value; }
        }
        private string _comfirmationToken;
        public string ComfirmationToken
        {
            get { return _comfirmationToken; }
            set { _comfirmationToken = value; }
        }
        private bool? _isConfirmed;
        public bool? IsConfirmed
        {
            get { return _isConfirmed; }
            set { _isConfirmed = value; }
        }
        private DateTime? _lastPasswordFailureDate;
        public DateTime? LastPasswordFailureDate
        {
            get { return _lastPasswordFailureDate; }
            set { _lastPasswordFailureDate = value; }
        }
        private DateTime? _passwordChangedDate;
        public DateTime? PasswordChangedDate
        {
            get { return _passwordChangedDate; }
            set { _passwordChangedDate = value; }
        }
        private long? _m_CompanyID;
        public long? M_CompanyID
        {
            get { return _m_CompanyID; }
            set { _m_CompanyID = value; }
        }
        private long? _m_TravellerID;
        public long? M_TravellerID
        {
            get { return _m_TravellerID; }
            set { _m_TravellerID = value; }
        }
        private long? _m_HotelID;
        public long? M_HotelID
        {
            get { return _m_HotelID; }
            set { _m_HotelID = value; }
        }
        private long? _m_ServiceCenterID;
        public long? M_ServiceCenterID
        {
            get { return _m_ServiceCenterID; }
            set { _m_ServiceCenterID = value; }
        }
        private long? _b_PosID;
        public long? B_PosID
        {
            get { return _b_PosID; }
            set { _b_PosID = value; }
        }
        private DateTime? _lastestLogin;
        public DateTime? LastestLogin
        {
            get { return _lastestLogin; }
            set { _lastestLogin = value; }
        }
        private int _queryStatus;
        public int QueryStatus
        {
            get { return _queryStatus; }
            set { _queryStatus = value; }
        }
        private long _createdBy;
        public long CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private long _updatedBy;
        public long UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        private DateTime _updatedDate;
        public DateTime UpdatedDate
        {
            get { return _updatedDate; }
            set { _updatedDate = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum A_MembershipColumns
    {
        ID,
        A_UserProfileID,
        Password,
        PasswordFailuresSinceLastSuccess,
        IsBlocked,
        ComfirmationToken,
        IsConfirmed,
        LastPasswordFailureDate,
        PasswordChangedDate,
        M_CompanyID,
        M_TravellerID,
        M_HotelID,
        M_ServiceCenterID,
        B_PosID,
        LastestLogin,
        QueryStatus,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum A_MembershipProcedure
    {
        p_A_Membership_Insert,
        p_A_Membership_Delete,
        p_A_Membership_Update,
        p_A_Membership_Get_List,
        p_A_Membership_Get_ByID,

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class webpages_Membership
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private DateTime? _createDate;
        public DateTime? CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        private string _confirmationToken;
        public string ConfirmationToken
        {
            get { return _confirmationToken; }
            set { _confirmationToken = value; }
        }
        private bool _isConfirmed;
        public bool IsConfirmed
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
        private int _passwordFailuresSinceLastSuccess;
        public int PasswordFailuresSinceLastSuccess
        {
            get { return _passwordFailuresSinceLastSuccess; }
            set { _passwordFailuresSinceLastSuccess = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private DateTime? _passwordChangedDate;
        public DateTime? PasswordChangedDate
        {
            get { return _passwordChangedDate; }
            set { _passwordChangedDate = value; }
        }
        private string _passwordSalt;
        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }
        private string _passwordVerificationToken;
        public string PasswordVerificationToken
        {
            get { return _passwordVerificationToken; }
            set { _passwordVerificationToken = value; }
        }
        private DateTime? _passwordVerificationTokenExpirationDate;
        public DateTime? PasswordVerificationTokenExpirationDate
        {
            get { return _passwordVerificationTokenExpirationDate; }
            set { _passwordVerificationTokenExpirationDate = value; }
        }
    }
    public enum webpages_MembershipColumns
    {
        UserId,
        CreateDate,
        ConfirmationToken,
        IsConfirmed,
        LastPasswordFailureDate,
        PasswordFailuresSinceLastSuccess,
        Password,
        PasswordChangedDate,
        PasswordSalt,
        PasswordVerificationToken,
        PasswordVerificationTokenExpirationDate,
    }
    public enum webpages_MembershipProcedure
    {
        p_webpages_Membership_Insert,
        p_webpages_Membership_Delete,
        p_webpages_Membership_Update,
        p_webpages_Membership_Get_List,
        p_webpages_Membership_Get_ByID,

    }
}
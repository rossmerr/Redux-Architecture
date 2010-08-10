using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Data.Interface
{
    public interface IUser
    {
        string Username { get; }
        string Password { get; }
        string Salt { get; }
        string PasswordQuestion { get; }

        string QuestionAnswer { get; }        
        string Email { get; }
        string Comment { get; }
        bool IsApproved { get; }
        bool IsLockedOut { get; }
        DateTime LastActiveDate { get; }
        DateTime LastLockoutDate { get; }
        DateTime LastLoginDate { get; }
        DateTime LastPasswordChangedDate { get; }
        DateTime DateCreated { get; }
        int LoginTrys { get; }

        void ChangePassword(string password, string salt);
        void ChangePasswordQuestionAndAnswer(string passwordQuestion, string passwordAnswer);
        void ResetPassword(string password);
        void UnlockUser();
        void LoginTry(int maxInvalidPasswordAttempts);
        void LoggedIn();

        void UpdateUser(string username, string email, string comment, bool isApproved, bool isLockedOut,
                        DateTime lastActivityDate, DateTime lastLockoutDate, DateTime lastLoginDate,
                        DateTime lastPasswordChangedDate, string passwordQuestion);
        
    }

    public interface IUser<TId> : IUser
    {
        TId Id { get; }
    }

    public abstract class User<TId> : IUser<TId>
    {
        public abstract string Username { get; protected set; }

        public abstract string Password { get; protected set; }

        public abstract string Salt
        { 
            get;
            protected set;
        }

        public abstract string PasswordQuestion
        { 
            get;
            protected set;
        }

        public abstract string QuestionAnswer
        { 
            get;
            protected set;
        }

        public abstract string Email
        { 
            get;
            protected set;
        }

        public abstract string Comment
        { 
            get;
            protected set;
        }

        public abstract bool IsApproved
        { 
            get;
            protected set;
        }

        public abstract bool IsLockedOut
        {
            get; protected set;
        }

        public abstract DateTime LastActiveDate
        { 
            get;
            protected set;
        }

        public abstract DateTime LastLockoutDate
        { 
            get;
            protected set;
        }

        public abstract DateTime LastLoginDate
        { 
            get;
            protected set;
        }

        public abstract DateTime LastPasswordChangedDate
        { 
            get;
            protected set;
        }

        public abstract DateTime DateCreated
        { 
            get;
            protected set;
        }

        public abstract int LoginTrys
        { 
            get;
            protected set;
        }

        public virtual void ChangePassword(string password, string salt)
        {
            this.Password = password;
            this.Salt = salt;
        }

        public virtual void ChangePasswordQuestionAndAnswer(string passwordQuestion, string questionAnswer)
        {
            this.PasswordQuestion = passwordQuestion;
            this.QuestionAnswer = questionAnswer;
        }

        public virtual void ResetPassword(string password)
        {
            this.Password = password;
        }

        public virtual void UnlockUser()
        {
            this.IsLockedOut = false;
            this.LoginTrys = 0;
        }

        public virtual void LoginTry(int maxInvalidPasswordAttempts)
        {
            this.LoginTrys++;
            if (this.LoginTrys >= maxInvalidPasswordAttempts)
            {
                this.IsLockedOut = true;
                this.LastLockoutDate = DateTime.UtcNow;
            }
        }

        public virtual void LoggedIn()
        {
            this.LastLoginDate = DateTime.UtcNow;
            this.LastActiveDate = this.LastLoginDate;
            this.LoginTrys = 0;           
        }

        public virtual void UpdateUser(string username, string email, string comment, bool isApproved, bool isLockedOut,
                               DateTime lastActivityDate, DateTime lastLockoutDate, DateTime lastLoginDate,
                               DateTime lastPasswordChangedDate, string passwordQuestion)
        {
            this.Email = email;
            this.Comment = comment;
            this.IsApproved = isApproved;
            this.IsLockedOut = isLockedOut;
            this.LastActiveDate = lastActivityDate;
            this.LastLockoutDate = lastLockoutDate;
            this.LastLoginDate = lastLoginDate;
            this.LastPasswordChangedDate = lastPasswordChangedDate;
            this.PasswordQuestion = passwordQuestion;
            this.Username = username;            
        }

        public virtual TId Id
        {
            get; protected set;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReduxArch.Core.DomainModel;
using ReduxArch.Data.Interface;

namespace ReduxArch.Data
{
public abstract class User<TId> : Entity, IUser<TId>
{
    // Methods
    protected User()
    {
    }

    public virtual void ChangePassword(string password, string salt)
    {
        Password = password;
        Salt = salt;
    }

    public virtual void ChangePasswordQuestionAndAnswer(string passwordQuestion, string questionAnswer)
    {
        PasswordQuestion = passwordQuestion;
        QuestionAnswer = questionAnswer;
    }

    public virtual void LoggedIn()
    {
        LastLoginDate = DateTime.UtcNow;
        LastActiveDate = LastLoginDate;
        LoginTrys = 0;
    }

    public virtual void LoginTry(int maxInvalidPasswordAttempts)
    {
        LoginTrys++;
        if (LoginTrys >= maxInvalidPasswordAttempts)
        {
            IsLockedOut = true;
            LastLockoutDate = DateTime.UtcNow;
        }
    }

    public virtual void ResetPassword(string password)
    {
        Password = password;
    }

    public virtual void UnlockUser()
    {
        IsLockedOut = false;
        LoginTrys = 0;
    }

    public virtual void UpdateUser(string username, string email, string comment, bool isApproved, bool isLockedOut, DateTime lastActivityDate, DateTime lastLockoutDate, DateTime lastLoginDate, DateTime lastPasswordChangedDate, string passwordQuestion)
    {
        Email = email;
        Comment = comment;
        IsApproved = isApproved;
        IsLockedOut = isLockedOut;
        LastActiveDate = lastActivityDate;
        LastLockoutDate = lastLockoutDate;
        LastLoginDate = lastLoginDate;
        LastPasswordChangedDate = lastPasswordChangedDate;
        PasswordQuestion = passwordQuestion;
        Username = username;
    }

    // Properties
    public virtual string Comment
    {
        get; protected set;
    }

    public virtual DateTime DateCreated
    {
        get; protected set;
    }

    public virtual string Email
    {
        get;
        protected set;
    }

    public virtual TId Id
    {
        get;
        protected set;
    }

    public virtual bool IsApproved
    {
        get; protected set;
    }

    public virtual bool IsLockedOut
    {
        get; protected set;
    }

    public virtual DateTime LastActiveDate
    {
        get; protected set;
    }

    public virtual DateTime LastLockoutDate
    {
        get; protected set;
    }

    public virtual DateTime LastLoginDate
    {
        get; protected set;
    }

    public virtual DateTime LastPasswordChangedDate
    {
        get; protected set;
    }

    public virtual int LoginTrys
    {
        get; protected set;
    }

    public virtual string Password
    {
        get; protected set;
    }

    public virtual string PasswordQuestion
    {
        get; protected set;
    }

    public virtual string QuestionAnswer
    {
        get; protected set;
    }

    public virtual string Salt
    { 
    get;
        protected set;
    }

    public virtual string Username
    { get;
        protected set;
    }
}

 
 
}

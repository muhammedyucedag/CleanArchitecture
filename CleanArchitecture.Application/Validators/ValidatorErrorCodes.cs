﻿using System.ComponentModel;

namespace CleanArchitecture.Application.Validators;

public enum ValidatorErrorCodes
{
    //ID
    [Description("ERR_INVALID_ID_FORMAT")] ERR_INVALID_ID_FORMAT,
    [Description("ERR_ID_REQUIRED")] ERR_ID_REQUIRED,

    //PASSWORD
    [Description("ERR_PASSWORD_WEAK")] ERR_PASSWORD_WEAK,
    [Description("ERR_PASSWORD_BLANK")] ERR_PASSWORD_BLANK,
    [Description("ERR_PASSWORD_DIGIT")] ERR_PASSWORD_DIGIT,
    [Description("ERR_PASSWORD_MIN_LENGTH")] ERR_PASSWORD_MIN_LENGTH,
    [Description("ERR_PASSWORD_MAX_LENGTH")] ERR_PASSWORD_MAX_LENGTH,
    [Description("ERR_PASSWORD_UPPERCASE")] ERR_PASSWORD_UPPERCASE,
    [Description("ERR_PASSWORD_LOWERCASE")] ERR_PASSWORD_LOWERCASE,
    [Description("ERR_PASSWORD_SPECIAL_CHARACTERS")] ERR_PASSWORD_SPECIAL_CHARACTERS,
    [Description("ERR_PASSWORD_FIRST_LAST_DIFFERENT")] ERR_PASSWORD_FIRST_LAST_DIFFERENT,

    //FULLNAME
    [Description("ERR_FULLNAME_REQUIRED")] ERR_FULLNAME_REQUIRED,
    [Description("ERR_FULLNAME_MIN_LENGTH")] ERR_FULLNAME_MIN_LENGTH,
    [Description("ERR_FULLNAME_MAX_LENGTH")] ERR_FULLNAME_MAX_LENGTH,
    [Description("ERR_FULLNAME_INVALID_FORMAT")] ERR_FULLNAME_INVALID_FORMAT,

    //USERNAME
    [Description("ERR_USERNAME_BLANK")] ERR_USERNAME_REQUIRED,
    [Description("ERR_USERNAME_MIN_LENGTH")] ERR_USERNAME_MIN_LENGTH,
    [Description("ERR_USERNAME_MAX_LENGTH")] ERR_USERNAME_MAX_LENGTH,

    //NAME
    [Description("ERR_NAME_REQUIRED")] ERR_NAME_REQUIRED,
    [Description("ERR_NAME_MIN_LENGTH")] ERR_NAME_MIN_LENGTH,
    [Description("ERR_NAME_MAX_LENGTH")] ERR_NAME_MAX_LENGTH,
    [Description("ERR_INVALID_NAME_FORMAT")] ERR_INVALID_NAME_FORMAT,

    //EMAIL
    [Description("ERR_EMAIL_REQUIRED")] ERR_EMAIL_REQUIRED,
    [Description("ERR_EMAIL_MIN_LENGTH")] ERR_EMAIL_MIN_LENGTH,
    [Description("ERR_EMAIL_MAX_LENGTH")] ERR_EMAIL_MAX_LENGTH,
    [Description("ERR_EMAIL_INVALID_FORMAT")] ERR_EMAIL_INVALID_FORMAT,

    //ADDRESS
    [Description("ERR_ADDRESS_REQUIRED")] ERR_ADDRESS_REQUIRED,
    [Description("ERR_ADDRESS_MIN_LENGTH")] ERR_ADDRESS_MIN_LENGTH,
    [Description("ERR_ADDRESS_MAX_LENGTH")] ERR_ADDRESS_MAX_LENGTH,
    [Description("ERR_INVALID_ADDRESS_FORMAT")] ERR_INVALID_ADDRESS_FORMAT,

    //LANGUAGE
    [Description("ERR_LANGUAGE_REQUIRED ")] ERR_LANGUAGE_REQUIRED,
    [Description("ERR_LANGUAGE_MIN_LENGTH ")] ERR_LANGUAGE_MIN_LENGTH,
    [Description("ERR_LANGUAGE_MAX_LENGTH ")] ERR_LANGUAGE_MAX_LENGTH,

    //PHONE
    [Description("ERR_PHONE_REQUIRED")] ERR_PHONE_REQUIRED,
    [Description("ERR_INVALID_PHONE_FORMAT")] ERR_INVALID_PHONE_FORMAT,

    //ASP NET CORE VALIDATOR FAILED
    [Description("ERR_CORE_UNKNOWN")] ERR_CORE_UNKNOWN,

}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace HotelReservationWPF.ViewModel.Core
{
    public abstract class ValidatorBase : IDataErrorInfo
    {

        #region Private properties

        string IDataErrorInfo.Error
        {
            get
            {
                throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");
            }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                if (!_CanValidate) return string.Empty;
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }

                string error = string.Empty;
                if (CustomMessage != null)
                {
                    if (CustomMessage.ContainsKey(propertyName))
                    {
                        error = CustomMessage[propertyName];
                        CustomMessage.Remove(propertyName);
                        return error;
                    }
                }


                var value = GetValue(propertyName);
                var results = new List<ValidationResult>(1);
                var result = Validator.TryValidateProperty(
                    value,
                    new ValidationContext(this, null, null)
                    {
                        MemberName = propertyName
                    },
                    results);
                if (!result)
                {
                    var validationResult = results.First();
                    error = validationResult.ErrorMessage;
                }
                return error;
            }
        }

        private object GetValue(string propertyName)
        {
            PropertyInfo propInfo = GetType().GetProperty(propertyName);
            return propInfo.GetValue(this);
        }

        #endregion

        #region Protected property

        public abstract bool _CanValidate { get; protected set; }

        public virtual Dictionary<string, string> CustomMessage { get; private set; } = new Dictionary<string, string>();

        #endregion

    }
}
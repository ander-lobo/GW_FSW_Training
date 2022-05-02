using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Gcsb.Connect.Training.Domain.Common;

namespace Gcsb.Connect.Training.Application.Repositories.Notification
{
    public interface INotifications
    {
        List<Domain::Notification> Notifications { get; set; }

        bool HasNotifications { get; }

        void AddNotification(string key, string message);

        void AddNotifications(ValidationResult validationResult);
    }
}

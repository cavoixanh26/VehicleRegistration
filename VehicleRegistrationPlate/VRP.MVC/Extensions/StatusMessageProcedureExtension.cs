using VRP.MVC.Constrants;

namespace VRP.MVC.Extensions
{
    public static class StatusMessageProcedureExtension
    {
        public static string StatusMessageLicensePlate(this int statusProcudure)
        {
            var message = "";
            switch (statusProcudure)
            {
                case 0:
                    message = StatusProcedureMessage.VerifyInformationOfRequester;
                    break;
                case 1:
                    message = StatusProcedureMessage.ApprovalInformationOfRequester;
                    break;
                case 2:
                    message = StatusProcedureMessage.RejectedInformationOfRequester;
                    break;
                case 3:
                    message = StatusProcedureMessage.VerifyVehicle;
                    break;
                case 4:
                    message = StatusProcedureMessage.ApprovalVehicle;
                    break;
                case 5:
                    message = StatusProcedureMessage.RejectedVehicle;
                    break;
                default:
                    message = StatusProcedureMessage.LicensePlateRotation;
                    break;
            }
            return message;
        }
    }
}

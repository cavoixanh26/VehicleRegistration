using System.ComponentModel;

namespace VRP.API.Models.Procedure
{
    public enum StatusProcudureEnum
    {
        [Description("Verify Information Of Requester")]
        VerifyInformationOfRequester = 0,
        [Description("Approval Information Of Requester")]
        ApprovalInformationOfRequester = 1,
        [Description("Rejected Information Of Requester")]
        RejectedInformationOfRequester = 2,
        [Description("Verify Vehicle")]
        VerifyVehicle = 3,
        [Description("Approval Vehicle")]
        ApprovalVehicle =4,
        [Description("Rejected Vehicle")]
        RejectedVehicle = 5,
        RotatedNumberLicensePlate = 6,
        CancelProcedure = 7,
    }
}

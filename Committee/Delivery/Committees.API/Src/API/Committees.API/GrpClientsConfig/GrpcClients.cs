using Committees.API.Protos;
using CommitteesManagement.Aggregator.Protos;
using ControlPanel.ORGHierararchy.Protos;

namespace _4EPlatform_Committees.GrpClientsConfig
{

    public static class GrpcClients
    {
        #region UserManagement
        public static void AddUserManagementGrpcClients(
            this IServiceCollection services,
            string userManagmentUrl)
        {
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(userManagmentUrl);
            services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(userManagmentUrl);
            services.AddGrpcServiceClient<UserDelegationProtoService.UserDelegationProtoServiceClient>(userManagmentUrl);
            services.AddGrpcServiceClient<DelegationUserProtoService.DelegationUserProtoServiceClient>(userManagmentUrl);
        }
        #endregion

        public static void AddCPAggregatorGrpcClients(this IServiceCollection services, string url)
        {

            services.AddGrpcServiceClient<OrgProtoService.OrgProtoServiceClient>(url);
            services.AddGrpcServiceClient<OrgMembersProtoService.OrgMembersProtoServiceClient>(url);
        }

    }
}

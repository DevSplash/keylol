﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Keylol.SteamBot.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ISteamBotCoordinator", CallbackContract=typeof(Keylol.SteamBot.ServiceReference.ISteamBotCoordinatorCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ISteamBotCoordinator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/Ping", ReplyAction="http://tempuri.org/ISteamBotCoordinator/PingResponse")]
        void Ping();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/RequestBots")]
        void RequestBots();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/AllocateBots", ReplyAction="http://tempuri.org/ISteamBotCoordinator/AllocateBotsResponse")]
        Keylol.Models.DTO.SteamBotDto[] AllocateBots(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/UpdateUser", ReplyAction="http://tempuri.org/ISteamBotCoordinator/UpdateUserResponse")]
        void UpdateUser(string steamId, string profileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/UpdateBot", ReplyAction="http://tempuri.org/ISteamBotCoordinator/UpdateBotResponse")]
        void UpdateBot(string id, System.Nullable<int> friendCount, System.Nullable<bool> online, string steamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/IsKeylolUser", ReplyAction="http://tempuri.org/ISteamBotCoordinator/IsKeylolUserResponse")]
        bool IsKeylolUser(string steamId, string botId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/OnBotNewFriendRequest")]
        void OnBotNewFriendRequest(string userSteamId, string botId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/OnUserBotRelationshipNone")]
        void OnUserBotRelationshipNone(string userSteamId, string botId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/OnBotNewChatMessage")]
        void OnBotNewChatMessage(string senderSteamId, string botId, string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISteamBotCoordinatorCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/GetAllocatedBots", ReplyAction="http://tempuri.org/ISteamBotCoordinator/GetAllocatedBotsResponse")]
        string[] GetAllocatedBots();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/RequestReallocateBots", ReplyAction="http://tempuri.org/ISteamBotCoordinator/RequestReallocateBotsResponse")]
        string[] RequestReallocateBots(int count);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/StopBot")]
        void StopBot(string botId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/AddFriend")]
        void AddFriend(string botId, string steamId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/RemoveFriend")]
        void RemoveFriend(string botId, string steamId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/SendChatMessage")]
        void SendChatMessage(string botId, string steamId, string message, bool logMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/BroadcastMessage")]
        void BroadcastMessage(string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/GetUserAvatarHash", ReplyAction="http://tempuri.org/ISteamBotCoordinator/GetUserAvatarHashResponse")]
        string GetUserAvatarHash(string botId, string steamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/GetUserProfileName", ReplyAction="http://tempuri.org/ISteamBotCoordinator/GetUserProfileNameResponse")]
        string GetUserProfileName(string botId, string steamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/GetFriendList", ReplyAction="http://tempuri.org/ISteamBotCoordinator/GetFriendListResponse")]
        string[] GetFriendList(string botId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/SetPlayingGame")]
        void SetPlayingGame(string botId, uint[] appIds, string gameName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/AddLicense")]
        void AddLicense(string botId, uint[] appIds);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISteamBotCoordinator/RedeemKey")]
        void RedeemKey(string botId, string cdKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISteamBotCoordinator/Curl", ReplyAction="http://tempuri.org/ISteamBotCoordinator/CurlResponse")]
        string Curl(string botId, string url);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISteamBotCoordinatorChannel : Keylol.SteamBot.ServiceReference.ISteamBotCoordinator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SteamBotCoordinatorClient : System.ServiceModel.DuplexClientBase<Keylol.SteamBot.ServiceReference.ISteamBotCoordinator>, Keylol.SteamBot.ServiceReference.ISteamBotCoordinator {
        
        public SteamBotCoordinatorClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public SteamBotCoordinatorClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public SteamBotCoordinatorClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SteamBotCoordinatorClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SteamBotCoordinatorClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Ping() {
            base.Channel.Ping();
        }
        
        public void RequestBots() {
            base.Channel.RequestBots();
        }
        
        public Keylol.Models.DTO.SteamBotDto[] AllocateBots(int count) {
            return base.Channel.AllocateBots(count);
        }
        
        public void UpdateUser(string steamId, string profileName) {
            base.Channel.UpdateUser(steamId, profileName);
        }
        
        public void UpdateBot(string id, System.Nullable<int> friendCount, System.Nullable<bool> online, string steamId) {
            base.Channel.UpdateBot(id, friendCount, online, steamId);
        }
        
        public bool IsKeylolUser(string steamId, string botId) {
            return base.Channel.IsKeylolUser(steamId, botId);
        }
        
        public void OnBotNewFriendRequest(string userSteamId, string botId) {
            base.Channel.OnBotNewFriendRequest(userSteamId, botId);
        }
        
        public void OnUserBotRelationshipNone(string userSteamId, string botId) {
            base.Channel.OnUserBotRelationshipNone(userSteamId, botId);
        }
        
        public void OnBotNewChatMessage(string senderSteamId, string botId, string message) {
            base.Channel.OnBotNewChatMessage(senderSteamId, botId, message);
        }
    }
}

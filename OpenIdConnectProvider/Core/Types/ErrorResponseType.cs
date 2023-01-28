using System.Runtime.Serialization;

namespace OpenIdConnectProvider.Core.Types;

public enum ErrorResponseType {

    [EnumMember(Value = "Invalid Request")]
    InvalidRequest
}
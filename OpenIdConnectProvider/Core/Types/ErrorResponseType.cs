using System.Runtime.Serialization;

namespace OpenIdConnectProvider.Core.Types;

public enum ErrorResponseType {

    // Request is missing a parameter so the server can’t proceed with the request.
    // This may also be returned if the request includes an unsupported parameter or repeats a parameter.
    [EnumMember(Value = "invalid_request")]
    invalid_request,

    // Client authentication failed, such as if the request contains an invalid
    //  client ID or secret. Send an HTTP 401 response in this case.
    [EnumMember(Value = "invalid_client")]
    invalid_client,

    // Authorization code (or user’s password for the password grant type)is invalid or expired.
    // This is also the error you would return if the redirect URL given in the authorization grant
    // does not match the URL provided in this access token request.
    [EnumMember(Value = "invalid_client")]
    invalid_grant,

    // Access token requests that include a scope (password or client_credentials grants),
    // this error indicates an invalid scope value in the request.
    [EnumMember(Value = "invalid_scope")]
    invalid_scope,

    // Client is not authorized to use the requested grant type. For example,
    // if you restrict which applications can use the Implicit grant,
    // you would return this error for the other apps.
    [EnumMember(Value = "unauthorized_client")]
    unauthorized_client,

    // If a grant type is requested that the authorization server doesn’t recognize,
    // use this code. Note that unknown grant types also use this specific error
    // code rather than using the invalid_request above.
    [EnumMember(Value = "unsupported_grant_type")]
    unsupported_grant_type
}
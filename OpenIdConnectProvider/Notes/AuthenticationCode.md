In OAuth, the authentication code is a short-lived token that is used to obtain an access token, which can be used to access a user's protected resources.

The following information is typically stored in an OAuth authentication code:

Client ID: The identifier for the client application that is requesting access to the user's resources.

Redirect URI: The URI to which the user will be redirected after they have granted or denied access to their resources.

State: An optional parameter that can be used to maintain state between the request and the callback. It is used to prevent cross-site request forgery (CSRF) attacks.

Scope: A list of the permissions that the client application is requesting. The user must grant these permissions in order for the client to access their resources.

User ID: A unique identifier for the user who is granting access to their resources.

It is important to store the authentication code securely, as it can be used to obtain an access token that can be used to access a user's protected resources. Typically, the authentication code is stored in a secure cookie or in-memory cache on the client side, and it is encrypted before it is sent over the network.

Once the user has granted access, the authentication code can be exchanged for an access token by sending a request to the authorization server. The access token is then used to make API requests on behalf of the user.
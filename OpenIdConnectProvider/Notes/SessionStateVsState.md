Session state and state in OAuth are two different concepts that are used for different purposes.

Session state refers to the information that is stored on the server side and is associated with a specific user. It is used to keep track of the user's interactions with the application and to maintain the state of the user's session.

State in OAuth, on the other hand, is a value that is passed between the client and the authorization server as part of the authorization request and response. The purpose of the state value is to prevent cross-site request forgery (CSRF) attacks.

When the client initiates an authorization request, it generates a random state value and includes it in the request. The authorization server returns the state value in the authorization response. When the client receives the response, it checks that the state value in the response matches the state value it generated in the request. If the values match, the client can be sure that the response is legitimate and not a result of a CSRF attack.

In summary, session state is used to maintain the user's session, while state in OAuth is used to prevent CSRF attacks.
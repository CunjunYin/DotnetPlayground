using OpenIdConnectProvider.Core.Models;
using OpenIdConnectProvider.Data.Models;
using OpenIdConnectProvider.Data.Repositories;

namespace OpenIdConnectProvider.Core.Services;

public class CodeValidater: ICodeValidater {
    DatabaseContext db;
    public CodeValidater(DatabaseContext db) {
        this.db = db;
    }

    public bool isValid(CodeExchangeModel model){

        if(model.grant_type.Equals("authorization_code")) {
            return authorizationCodeValidate(model);
        }

        if(model.grant_type.Equals("refresh_token")) {
            return refreshTokenValidate(model);
        }

        return true;
    }

    private bool authorizationCodeValidate(CodeExchangeModel model){
        AuthenticationCode code = db.AuthenticationCodes.Where(
            c => c.Code == model.code
        ).FirstOrDefault();

        if(code == null) {
            return false;
        }

        if(code.ClientId.Equals(model.client_id)) {
            return false;
        }
        return true;
    }

    private bool refreshTokenValidate(CodeExchangeModel model){
        return true;
    }
    
}
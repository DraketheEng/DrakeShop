using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace DrakeShop.IdentityServer
{

    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { 
            new ApiResource("ResourceCatalog"){Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount"){Scopes = { "DiscounFullPermission" } },
            new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" } },
            new ApiResource("ResourceCargo"){Scopes = { "CargoFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] { 
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<Client> Clients => new Client[] {

            //Visitor
            new Client
            {
                ClientId = "DrakeShopVisitorId",
                ClientName = "DrakeShop visitor user",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("drakeshopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission" }
            },

            //Manager
             new Client
            {
                ClientId = "DrakeShopManagerId",
                ClientName = "DrakeShop Manager user",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("drakeshopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", " CatalogFullPermission " }
            },

             //Admin
              new Client
            {
                ClientId = "DrakeShopAdminId",
                ClientName = "DrakeShop Admin user",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("drakeshopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 600,
            },
        };
    }

}
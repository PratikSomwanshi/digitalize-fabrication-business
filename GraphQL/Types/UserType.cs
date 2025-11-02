using DigitalizeFabricationBussiness.Models;
using HotChocolate.Types;

namespace DigitalizeFabricationBussiness.GraphQL.Types;

/// <summary>
/// GraphQL Object Type for User entity
/// Defines the GraphQL schema representation of a User
/// This type is used for querying user data through GraphQL
/// </summary>
public class UserType : ObjectType<User>
{
    /// <summary>
    /// Configures the User type and its fields for GraphQL schema
    /// </summary>
    /// <param name="descriptor">Type descriptor to configure the User type</param>
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        // Set the GraphQL type name
        descriptor.Name("User");

        // Set description for the User type
        descriptor.Description("Represents a user in the fabrication business system");

        // Configure UserId field
        descriptor
            .Field(u => u.UserId)
            .Description("Unique identifier for the user (GUID)");

        // Configure UserPhone field
        descriptor
            .Field(u => u.UserPhone)
            .Description("Phone number of the user");

        // Configure UserEmail field
        descriptor
            .Field(u => u.UserEmail)
            .Description("Email address of the user");

        // Configure UserName field
        descriptor
            .Field(u => u.UserName)
            .Description("Username for authentication");

        // Configure UserFullName field
        descriptor
            .Field(u => u.UserFullName)
            .Description("Full name of the user");

        // Ignore password field - SECURITY: Never expose passwords in GraphQL
        descriptor
            .Field(u => u.UserPassword)
            .Ignore();

        // Configure IsActive field
        descriptor
            .Field(u => u.IsActive)
            .Description("Indicates whether the user account is active");

        // Configure IsAdmin field
        descriptor
            .Field(u => u.IsAdmin)
            .Description("Indicates whether the user has admin privileges");

        // Configure Roles navigation property
        descriptor
            .Field(u => u.Roles)
            .Ignore();

        // Configure Address navigation property
        descriptor
            .Field(u => u.Address)
            .Description("Address information of the user");

        // Configure CreatedAt from BaseEntity
        descriptor
            .Field(u => u.CreatedAt)
            .Description("Timestamp when the user was created");

        // Configure UpdatedAt from BaseEntity
        descriptor
            .Field(u => u.UpdatedAt)
            .Description("Timestamp when the user was last updated");
    }
}

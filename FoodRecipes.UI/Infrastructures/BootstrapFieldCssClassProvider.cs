using Microsoft.AspNetCore.Components.Forms;

namespace FoodRecipes.UI.Infrastructures;

public class BootstrapFieldCssClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        if (editContext.IsModified(fieldIdentifier)) return isValid ? "is-valid" : "is-invalid";

        return isValid ? "" : "is-invalid";
    }
}

// Ignore Spelling: Css
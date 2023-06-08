using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace RapiDocDemo;

[Dependency(ReplaceServices = true)]
public class RapiDocDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "RapiDocDemo";
}

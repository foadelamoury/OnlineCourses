

using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Application.Common.Resources;
public class LocService
{
  private IStringLocalizer _localizer;
  public LocService()
  {

  }
  public LocService(IStringLocalizerFactory factory)
  {
    var type = typeof(SharedResource);
    var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
    _localizer = factory.Create("SharedResource", assemblyName.Name);
  }

  public LocalizedString GetLocalizedString(string key)
  {
    var str = _localizer[key];
    return str;
  }
}

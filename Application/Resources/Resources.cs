

using Application.Common.Helpers;
using System.Globalization;

namespace Application.Common.Resources;
public class Resources
{
  private readonly LocService _localizer;
  public Resources(LocService localizer)
  {
    _localizer = localizer;
  }

  public static Dictionary<string, string> MapLabel { get; set; }

  public static string GetCurrentLanguage()
  {
    return CultureInfo.CurrentCulture.Name.Substring(0, 2);
  }

  //public static string MapFieldToLanguage()
  //{
  //  return Resources.GetCurrentLanguage() == EnumLanguageAbbr.En.ToString() ? "_E" : "_A";
  //}


  public static string AdaptDateForDB(DateTime Value, string Time)
  {
    string Ret = "";
    string _Time = (string.IsNullOrEmpty(Time)) ? "" : " ";
    if (Value != NullHelper.DateTime)
    {
      Ret = string.Format("{1}/{0}/{2}", Value.Day, Value.Month, Value.Year);
      Ret = string.Format("'{0}" + _Time + "{1}'", Ret, Time);
    }
    return Ret;
  }
  public static string AdaptForLike(string Value)
  {
    string Ret = Value.Replace("[", "[[]");
    Ret = Ret.Replace("%", "[%]");
    //Ret = Ret.Replace("_", "[_]");
    Ret = Ret.Replace("'", "''");

    return Ret;
  }

  public static List<ListItemObject> pagingList()
  {
    List<ListItemObject> listItemObjects = new List<ListItemObject>();
    listItemObjects.Add(new ListItemObject { Value = "5", Text = "5" });
    listItemObjects.Add(new ListItemObject { Value = "10", Text = "10" });
    listItemObjects.Add(new ListItemObject { Value = "20", Text = "20" });
    listItemObjects.Add(new ListItemObject { Value = "50", Text = "50" });
    listItemObjects.Add(new ListItemObject { Value = "100", Text = "100" });
    listItemObjects.Add(new ListItemObject { Value = "200", Text = "200" });
    listItemObjects.Add(new ListItemObject { Value = "1000", Text = "1000" });
    return listItemObjects;
  }

  public static string SubStringText(string Value, int Length)
  {
    string Ret = Value;

    if (!string.IsNullOrEmpty(Ret))
    {
      if (Length > 0)
        Ret = (Ret.Length <= Length) ? Ret : Ret.Substring(0, Length) + (Ret.IndexOf(' ', Length) > 0 ? Ret.Substring(Length, Ret.IndexOf(' ', Length) - Length) : "") + "...";
    }

    return Ret;
  }

  public static string AdaptForNormalize(string Value)
  {
    string Ret = "";
    if(Value != null)
    {
    Ret = Value.Replace("أ", "ا");
    Ret = Ret.Replace("إ", "ا");
    Ret = Ret.Replace("آ", "ا");
    Ret = Ret.Replace("ة", "ه");
    Ret = Ret.Replace("ت", "ه");
    Ret = Ret.Replace("ى", "ي");
    Ret = Ret.Replace("ؤ", "و");
    Ret = Ret.Replace(".", "");
    Ret = Ret.Replace("0", "");
    Ret = Ret.Replace("-", "");
    Ret = Ret.Replace(" ", "");
    }
    return Ret.ToUpper();
  }


  #region Validation

  public string RequiredErrorMsg(string ProprtyName)
  {
    string key = _localizer.GetLocalizedString("Must Be Not Empty");
    string keyProp = _localizer.GetLocalizedString(ProprtyName);
    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
      return $"{key} {keyProp}";
    else
      return $"{keyProp} {key}";
  }

  public string MinmumandMaximumLengthErrorMsg(string Property, int Length, string LengthType = "Maximum", string PropertyType = "Character")
  {
    string keyLength = _localizer.GetLocalizedString($"{LengthType} Length");
    string keyIs = _localizer.GetLocalizedString("Is");
    string keyProp = _localizer.GetLocalizedString(Property);
    string keyLengthType = _localizer.GetLocalizedString(LengthType);
    string keyPropType = _localizer.GetLocalizedString(PropertyType);
    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
      return $"{keyLength} {keyProp} {keyIs} {Length} {keyPropType}";
    else
      return $"{Property} {LengthType} Length Is {Length} {PropertyType}.";
  }

  public string IdErrorMsg(string EntityName)
  {
    string key = _localizer.GetLocalizedString("Must Be Not Empty");
    string keyId = _localizer.GetLocalizedString("Id");
    string keyEntity = _localizer.GetLocalizedString(EntityName);
    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
      return $"{key} {keyId} {keyEntity}";
    else
      return $"{keyEntity} {keyId} {key}";
  }



  #endregion

}

public class ListItemObject
{
  public string Text { get; set; }
  public string Value { get; set; }

}


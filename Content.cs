using System;
using System.Text;
using System.Collections;

namespace IssueManager.Mail
{
  /// <summary>
  /// e-mail content template wrapper
  /// </summary>
  public class ContentElement
  {
    private string m_sTemplate;
    Hashtable m_Content = new Hashtable();
    public ContentElement(string sTemplate)
    {
      m_sTemplate = sTemplate;
    }

    /// <summary>
    /// Set the content for the placeholders in the email templates
    /// </summary>
    /// <param name="sAttributeName"></param>
    /// <param name="sAttributeValue"></param>
    /// <returns>return false if attribute already exists,otherwise return true</returns>
    public Boolean SetAttribute (string sAttributeName,string sAttributeValue)
    {
      if(m_Content.ContainsKey(sAttributeName) == true)
      {
        return false;
      }
      else
      {
        m_Content.Add(sAttributeName,sAttributeValue);
        return true;
      }
    }
  
    /// <summary>
    /// GetContent populate the template with the content attributes
    /// </summary>
    /// <returns>the populated template</returns>
    public string GetContent()
    {
      //do the actual parseing 
      StringBuilder sbBuilder = new StringBuilder(m_sTemplate);

      //replace carriage returns by line break
      sbBuilder.Replace("\r\n","<br>");
      //replace place holders by values
      foreach (string sAttNames in m_Content.Keys)
      {
       sbBuilder.Replace(("{"+sAttNames+"}"),(string)m_Content[sAttNames]);
      }

      //return the parsed string
      return sbBuilder.ToString();

    }
  }
}

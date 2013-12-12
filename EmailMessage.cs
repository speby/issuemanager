using System;

namespace IssueManager.Mail
{
	/// <summary>
	/// represents an email message
	/// </summary>
	public class EmailMessage
	{
    private string m_sRecipient; //name or id of the recipient
    private string m_sSender; //e-mail of the sender
    private ContentElement m_Subject;//the content of the subject
    private ContentElement m_Body;//the content of the body
    
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="sRecipient">name or id of the recipient</param>
    /// <param name="sSender">e-mail of the sender</param>
    /// <param name="sBodyTemplate">the template of the subject</param>
    /// <param name="sSubjectTemplate">the template of the body</param>
    public EmailMessage(string sRecipient,string sSender,string sBodyTemplate,string sSubjectTemplate)
		{
      m_sRecipient = sRecipient;
      m_sSender = sSender;
      m_Subject = new ContentElement(sSubjectTemplate);
      m_Body = new ContentElement(sBodyTemplate);  
		}

    /// <summary>
    /// set a subject element
    /// </summary>
    /// <param name="sName">name of the element</param>
    /// <param name="sValue">value of the element</param>
    /// <returns>false if the element already exist,true on success</returns>
    public Boolean  SetSubjectElement(string sName,string sValue)
    {
      return m_Subject.SetAttribute(sName,sValue);
    }

    /// <summary>
    /// Set a body element 
    /// </summary>
    /// <param name="sName">name of the element</param>
    /// <param name="sValue">value of the element</param>
    /// <returns>false if the element already exist,true on success</returns>
    public Boolean SetBodyElement(string sName,string sValue)
    {
      return m_Body.SetAttribute(sName,sValue);
    }

    /// <summary>
    /// get the populated subject
    /// </summary>
    /// <returns>populated subject</returns>
    public string GetSubject()
    {
      return m_Subject.GetContent();
    }

    /// <summary>
    /// get the populated body
    /// </summary>
    /// <returns>populated body</returns>
    public string GetBody()
    {
      return m_Body.GetContent();
    }
    /// <summary>
    /// Return Recipient's e-mail
    /// </summary>
    /// <returns>Recipient's e-mail</returns>
    public string GetRecipient()
    {
      return m_sRecipient;
    }

    /// <summary>
    /// Return Sender's e-mail
    /// </summary>
    /// <returns>Sender's e-mail</returns>
    public string GetSender()
    {
      return m_sSender;
    }
	}
}

using System;
using System.Collections;

namespace IssueManager.Mail
{
  /// <summary>
  /// collects and dispatches email messages
  /// </summary>
  public class Postman
  {
    protected CCUtility Utility ; 

    //new issue messages Hashtable
    private Hashtable m_NewIssueMessages = new Hashtable();
    //changed issue messages Hashtable
    private Hashtable m_ChangedIssueMessages = new Hashtable();

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="Util">initialized util object</param>
    public Postman(ref CCUtility Util)
    {
      Utility = Util;
    }

    /// <summary>
    /// send ALL available messages 
    /// </summary>
    public void DeliverMail()
    {
      try
      {
        SendMail(m_NewIssueMessages);
        SendMail(m_ChangedIssueMessages);
      }
      catch{}
      
    }

    /// <summary>
    /// send messages available in hashtable
    /// </summary>
    /// <param name="hashMessages"></param>
    private void SendMail(Hashtable hashMessages)
    {
      foreach( EmailMessage msg in hashMessages.Values)
      {
        System.Web.Mail.MailMessage newMsg = new System.Web.Mail.MailMessage();
        newMsg.BodyFormat=System.Web.Mail.MailFormat.Html;
        newMsg.From = msg.GetSender();
        string sTmp = "user_name='"+msg.GetRecipient()+"' ";
        newMsg.To=Utility.Dlookup("users","email","user_name='"+msg.GetRecipient()+"'");
        newMsg.Subject = msg.GetSubject();
        newMsg.Body = msg.GetBody();
        System.Web.Mail.SmtpMail.SmtpServer = Utility.SmtpServer();
        System.Web.Mail.SmtpMail.Send(newMsg);

      }
    }

    /// <summary>
    /// Add a message to the hashtable
    /// </summary>
    /// <param name="objEmailMessage">an initialized e-mail object</param>
    /// <param name="bNewIssueMessage">true - new issue message,false - changed issue message</param>
    public void AddMessage(EmailMessage objEmailMessage,Boolean bNewIssueMessage)
    {
      try
      {
        if(bNewIssueMessage == true)
        {
          //if this is a new issue message
          if(m_NewIssueMessages.Contains(objEmailMessage.GetRecipient()))
          {
            return;
          }
          else
          {
            m_NewIssueMessages.Add(objEmailMessage.GetRecipient(),objEmailMessage);
          }
        }
          //if this is a new issue message
        else 
        if(m_ChangedIssueMessages.Contains(objEmailMessage.GetRecipient()))
        {
          return;
        }
        else
        {
          m_ChangedIssueMessages.Add(objEmailMessage.GetRecipient(),objEmailMessage);
        }  
      }
      catch{}
    }
  }
}

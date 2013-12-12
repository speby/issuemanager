using System;
using CoreLab.MySql;
namespace IssueManager
{
    namespace ViewCvs
    {
    
        /// <summary>
        /// wraps viewcvs actions
        /// </summary>
        public class ViewCvs
        {
            private MySqlConnection m_ViewCVSConnection;
			private Boolean m_bOpenDBFailed = false;

            public ViewCvs()
            {
                //set the connection flag to false - db is not open
                string myConnectionString =System.Configuration.ConfigurationSettings.AppSettings["sViewCVSDBConnectionString"];//"User=root; Host=192.168.1.102; Port=3306; Database=ViewCVS";
                //open the mysql database connection
                m_ViewCVSConnection = new CoreLab.MySql.MySqlConnection (myConnectionString);
                m_ViewCVSConnection.Password = System.Configuration.ConfigurationSettings.AppSettings["sViewCVSDBPassord"];
            }
            public void OpenDB()
            {
                try
				{
					m_ViewCVSConnection.Open();
				}
				catch (MySqlException e) 
				{
					e.ToString();
					m_bOpenDBFailed = true;
				}
				
            }
            public void CloseDB()
            {
                m_ViewCVSConnection.Close();
            }
            public System.Data.DataSet GetIssueFiles(int iIssueID)
            {

				System.Data.DataSet ds = new System.Data.DataSet();
				try
				{

					string sSql = "SELECT dirs.dir, files.file, repositories.repository, checkins.revision, descs.description FROM (((checkins LEFT JOIN descs ON checkins.descid = descs.id) LEFT JOIN dirs ON (checkins.dirid = dirs.id) ) LEFT JOIN files ON  (checkins.fileid = files.id)) LEFT JOIN repositories ON  (checkins.repositoryid = repositories.id)WHERE (descs.description LIKE '%Bug Id: "+iIssueID.ToString()+"\n%%' OR descs.description LIKE '%Bug Id:"+iIssueID.ToString()+"\n%%')";
					CoreLab.MySql.MySqlCommand myCommand = new CoreLab.MySql.MySqlCommand(sSql,m_ViewCVSConnection);

					CoreLab.MySql.MySqlDataAdapter adapter = new CoreLab.MySql.MySqlDataAdapter(myCommand);
                
					adapter.Fill(ds);
				}
				catch (Exception e)
				{
					throw(e);
				}
                return ds;

            }
        }
    }
}

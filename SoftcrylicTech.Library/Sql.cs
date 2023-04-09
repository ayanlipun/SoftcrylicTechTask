namespace SoftcrylicTech.Library
{
    internal static class Sql
    {
        internal static string GetEventDetails(string title)
        {
            string sql = @"SELECT [id]      ,[Title]      ,[Description]      ,[Date]      ,[ModeOfEvent]      ,[Venue]      ,[Website]      ,[LinkForDetails]      ,[SpeakerId]  FROM [dbo].[tblEvent] where Title= '" + title + "'";
            return sql;

        }
    }
}

using System;

namespace School.DataAccess
{
    internal class Connections
    {
        public static string SchoolCS
        {
            get
            {
                return Environment.GetEnvironmentVariable("CSSchool", EnvironmentVariableTarget.Machine);
            }
        }
    }
}

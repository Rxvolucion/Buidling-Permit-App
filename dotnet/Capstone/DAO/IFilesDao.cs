using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IFilesDao
    {
        Files InsertFileURLs(string URL);
        Files GetFileById(int fileId);

    }

}

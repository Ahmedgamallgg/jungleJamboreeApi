using File2 = System.IO;

namespace WebApi.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //1. file location path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Files", folderName);
            
            //2. get file name and make it unique
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            //3. get file path

            var filePath = Path.Combine(folderPath,fileName);

            // use file stream to make a copy of the file

            using var filestream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(filestream);

            return $"Files\\{folderName}\\{fileName}";
        }
        public static int DeleteFile(string imageUrl)
        {
            try
            {
 
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageUrl);

                

                

                


                Console.WriteLine($"File Path: {filePath}");

                // Check if the file exists at the specified path
                var exist = File2.File.Exists(filePath);
                if (exist)
                {
                    // Delete the file
                    File2.File.Delete(filePath);
                    return 0; // Return 0 to indicate success
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return -1; // Return -1 to indicate the file does not exist
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return -2; // Return -2 to indicate an error occurred
            }
        }

        

    }
}

namespace Admin_Dashboard.Helpers
{
	public class DocumentSettings
	{
		public static string UploadFile(IFormFile file, string folderName)
		{
			//1. file location path
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images", folderName);

			//2. get fileName  and make it unique
			var fileName = $"{Guid.NewGuid().ToString()}-{Path.GetFileName(file.FileName)}";
			//3. Get file path

			var filePath = Path.Combine(folderPath, fileName);

			//4. use file stream to make a copy
			using var fileStream = new FileStream(filePath, FileMode.Create);

			file.CopyTo(fileStream);

			return filePath;

		}

		public static bool DeleteFile(string ImageUrl, string folderName) 
		{
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", folderName);

			var filePath = Path.Combine(folderPath, ImageUrl);

			if(File.Exists(filePath))
			{
				File.Delete(filePath);
				return true;
			}
			return false;
		}
	}
}

namespace LapShop.Utility
{
    public  class Helper
    {

        public static async Task<string> UploadImage(List<IFormFile> files,  string  folderName)
        {
            foreach (var file in files)
            {

                if (file.Length > 0)
                {
                    string imageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";

                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\"+ folderName, imageName);

                    using (var stream = System.IO.File.Create(filePaths))
                    {

                        await file.CopyToAsync(stream);

                        return imageName;

                    }

                }

            }
            return string.Empty;
        }

    }
}

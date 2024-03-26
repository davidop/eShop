namespace Catalog.API.Helpers
{
    public static class Utils
    {
        public static async Task<string> DownloadAndSavePhoto(string imageUrl, string name)
        {
            string fileName = $"{name}";

            string filePath = Path.Combine("Pics", fileName);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(imageUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            // Save the photo to Pics directory
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await stream.CopyToAsync(fileStream);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception($"Failed to download photo. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to download photo: {ex.Message}");
                }
            }

            return fileName;
        }
    }
}

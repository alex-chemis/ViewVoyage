using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using S3ApiMicroservice.Dtos;

namespace S3ApiMicroservice.Controllers;

[Route("api/v1")]
[ApiController]
public class PlayerController(IAmazonS3 s3Client) : ControllerBase
{
    [HttpGet("{bucketName}/{key}")]
    public async Task<IActionResult> Play(string bucketName, string key)
    {
        var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);
        if (!bucketExists) return NotFound($"Bucket {bucketName} does not exist.");
        var s3Object = await s3Client.GetObjectAsync(bucketName, key);
        return File(s3Object.ResponseStream, s3Object.Headers.ContentType);
    }
}
using ICS.Domain.Models;
using ICS.Shared;
using ICS.WebApplication.Commands.Read;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ICS.WebApp.Controllers
{
	///TODO: лучше назвать как ProfileEmployee
	/// <summary>
	/// Контроллер профиля
	/// </summary>
	[ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IReadCommand<ProfileResult> _profileReadCommand;
        private readonly EmployeeReadCommand _employeeReadCommand;

        private readonly ProfileWriteCommand _profileWriteCommand;

        public ProfileController(
            IReadCommand<ProfileResult> profileReadCommand,
            EmployeeReadCommand employeeReadCommand,
            ProfileWriteCommand profileWriteCommand)
        {
            _profileReadCommand = profileReadCommand;
            _employeeReadCommand = employeeReadCommand;
            _profileWriteCommand = profileWriteCommand;
        }

        [HttpGet]
        [Route("{profileId:guid}/employee/{employeeId:guid}")]
        public async Task<IActionResult> GetById(Guid profileId, Guid employeeId)
        {
            var profileResult = await _profileReadCommand.ExecuteAsync(profileId);
            var employeeResult = await _employeeReadCommand.ExecuteAsync(employeeId);

            var userInfo = new UserInfoResult
            {
                Profile = profileResult,
                ShortName = employeeResult.Organization?.ShortName,
                AcademicDegree = employeeResult.AcademicDegree,
                AcademicRank = employeeResult.AcademicRank,
                Education = employeeResult.Education,
                Fio = employeeResult.Passport?.ToFio(),
                Email = employeeResult.Contact?.Email,
                ///TODO: реализовать получение и заполнение факсов + база
                Fax = null,
                MobilePhoneNumber = employeeResult.Contact?.MobilePhoneNumber,
                WorkPlace = employeeResult.WorkPlace,
                Position = employeeResult.Position
            };

            var jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var objectJson = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(userInfo, jsonOptions);

            /*var objectJson = JsonConvert.SerializeObject(userInfo, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });*/

            /*var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(objectJson)
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");*/

            var mediaType = new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            var result = new FileContentResult(objectJson, mediaType);

            return result;
        }

        [HttpPost]
        [Route("{profileId:guid}")]
        public async Task UpdateAsync(Guid profileId, ProfileDto profileDto)
        {
            Contract.Argument.IsNotNull(profileDto, nameof(profileDto));

            //var profileId = GetProfileId();

            await _profileWriteCommand.UpdateAsync(profileId, profileDto).ConfigureAwait(false);
        }

        private Guid GetProfileId()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var profileId = Guid.Parse(identityClaims.FindFirst("ProfileId").Value);

            return profileId;
        }
    }
}

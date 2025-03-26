using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace Impostor.Server.Http;

[Route("/api/filters")]
public sealed class FiltersController : ControllerBase
{
    private static readonly string[] Value = new[]
        {
                // "Tags",
                // "PlayerSpeed",
                // "Roles",
                // "KillCooldown",
                // "VotingTime",
                "NumImposters",

                // "VisualTasks",
                // "AnonymousVotes",
                // "ConfirmEjects",
                // "DiscussionTime",
                // "EmergencyCooldown",
                // "NumEmergencyMeetings",
                // "NumCommonTasks",
                // "NumShortTasks",
                // "NumLongTasks",
                // "KillDistance",
        };

    [HttpGet]
    public IActionResult GetFilters([FromHeader] AuthenticationHeaderValue authorization)
    {
        if (authorization.Scheme != "Bearer" || authorization.Parameter == null)
        {
            return BadRequest();
        }

        return Ok(new
        {
            filters = Value,
        });
    }
}

// As a matter of fact currently we can only achieve filter by impostor num
// {"filters":["Tags","PlayerSpeed","Roles","KillCooldown","VotingTime","NumImposters","VisualTasks","AnonymousVotes","ConfirmEjects","DiscussionTime","EmergencyCooldown","NumEmergencyMeetings","NumCommonTasks","NumShortTasks","NumLongTasks","KillDistance"]}

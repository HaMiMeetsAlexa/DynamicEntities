// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateADynamicEntityWithReplaceTests.cs" company="Millmann.Biz">
//   (c) 2022 by Hans Ludwig Millmann
// </copyright>
// <summary>
//   The update a dynamic entity with replace tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DynamicEntities.Test
{
    using Xunit;

    /// <summary>
    /// The update a dynamic entity with replace tests.
    /// </summary>
    public class UpdateADynamicEntityWithReplaceTests
    {
        /// <summary>
        /// The test me.
        /// </summary>
        [Fact]
        public void TestCreateSkillResponse()
        {
            var skillResponse = UpdateADynamicEntityWithReplace.CreateSkillResponse();
            Assert.NotNull(skillResponse);
        }    
    }
}
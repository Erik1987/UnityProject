using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace Tests
{
    public class GeneralTest
    {
        [Test]
        public void PlayerHealthShouldNotFallBelowZero()
        {
            var player = new Player();
            var playerHealth = player.currentHealth;
            Assert.GreaterOrEqual(playerHealth, 0);
        }
    }
}

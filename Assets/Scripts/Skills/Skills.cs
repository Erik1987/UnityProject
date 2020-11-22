using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Skills : MonoBehaviour
{

    public void ShootProjectileInDirection(
        GameObject projectile,
        Vector3 position,
        Vector3 direction,
        float projectileSpeed
        )
    {
        float textureAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject newProjectile = Instantiate(projectile, position, Quaternion.Euler(0, 0, textureAngle));
        newProjectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        Destroy(newProjectile, 10f);
    }

    public void ShootProjectilesInCone(
        GameObject projectile,
        Vector3 position,
        Vector3 direction,
        float projectileSpeed,
        int projectileCount,
        float projectileSpread,
        float projectileScale
        )
    {
        // Calculate projectile angles
        float[] angles = new float[projectileCount];
        int anglesIndex = 0;
        if (projectileCount % 2 != 0)
        {
            angles[0] = 0;
            anglesIndex = 1;
        }
        
        while (anglesIndex < projectileCount)
        {
            int positiveOrNegative = anglesIndex % 2 == 0 ? -1 : 1;
            int round = (int)Math.Round((decimal)anglesIndex / 2, 0, MidpointRounding.AwayFromZero);
            angles[anglesIndex] = projectileSpread * positiveOrNegative * round;
            anglesIndex++;
        }

        // TODO: merge these two loops together, both run as many time as projectileCount is

        // Create projectiles
        for (int i = 0; i < projectileCount; i++)
        {
            float textureAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            textureAngle += angles[i];
            GameObject newProjectile = Instantiate(projectile, position, Quaternion.Euler(0, 0, textureAngle));
            newProjectile.transform.localScale *= projectileScale;
            newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.right * projectileSpeed;
            Destroy(newProjectile, 10f);
        }
    }

    public IEnumerator ShootProjectilesInConeWithWaves(
        GameObject projectile,
        Vector3 position,
        Vector3 direction,
        float projectileSpeed,
        int projectileCount,
        float projectileSpread,
        float projectileScale,
        int projectileWaves,
        float waveCooldownTime = 0.2f
        )
    {
        // Calculate projectile angles
        float[] angles = new float[projectileCount];
        int anglesIndex = 0;
        if (projectileCount % 2 != 0)
        {
            angles[0] = 0;
            anglesIndex = 1;
        }
        
        while (anglesIndex < projectileCount)
        {
            int positiveOrNegative = anglesIndex % 2 == 0 ? -1 : 1;
            int round = (int)Math.Round((decimal)anglesIndex / 2, 0, MidpointRounding.AwayFromZero);
            angles[anglesIndex] = projectileSpread * positiveOrNegative * round;
            anglesIndex++;
        }
        // Create projectiles
        for (int waves = 0; waves < projectileWaves; waves++)
        {
            for (int i = 0; i < projectileCount; i++)
            {
                float textureAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                textureAngle += angles[i];
                GameObject newProjectile = Instantiate(projectile, position, Quaternion.Euler(0, 0, textureAngle));
                newProjectile.transform.localScale *= projectileScale;
                newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.right * projectileSpeed;
                Destroy(newProjectile, 10f);
            }
            if (projectileWaves > 1)
            {
                yield return new WaitForSeconds(waveCooldownTime);
            }
        }
    }

    public void ShootProjectilesInCircle(
        GameObject projectile,
        Vector3 position,
        float projectileSpeed,
        int projectileCount,
        float projectileScale
        )
    {
        float angleStep = 360f / projectileCount;
        float angle = 0f;
        
        for (int i = 0; i < projectileCount; i++)
        {
            float dirX = position.x + Mathf.Sin(angle * Mathf.PI / 180);
            float dirY = position.y + Mathf.Cos(angle * Mathf.PI / 180);

            Vector2 projectileVector = new Vector2(dirX, dirY);
            Vector2 projectileDirection = (projectileVector - (Vector2) position).normalized;
            float textureAngle = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
            GameObject newProjectile = Instantiate(projectile, position, Quaternion.Euler(0, 0, textureAngle));
            newProjectile.transform.localScale *= projectileScale;
            newProjectile.GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileSpeed;
            Destroy(newProjectile, 10f);
            angle += angleStep;
        }
    }

}

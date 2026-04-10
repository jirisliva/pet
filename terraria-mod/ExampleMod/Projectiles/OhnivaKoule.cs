using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HelloMod.Projectiles
{
    /// <summary>
    /// Ohnivá Koule – magický projektil vystřelený Slunečním Mečem.
    ///
    /// Chování:
    ///   - Letí vpřed jako šíp (aiStyle = Arrow)
    ///   - Prostřelí až 3 nepřátele
    ///   - Vydává oranžové světlo
    ///   - Zapálí zásažené NPC na 3 sekundy
    ///   - Při zániku vytvoří efekt jiskřiček (dust)
    /// </summary>
    public class OhnivaKoule : ModProjectile
    {
        // Jméno je v Localization/en-US.hjson (tModLoader 1.4.4+)

        // Počet animačních snímků – odpovídá počtu framů v OhnivaKoule.png
        private const int FrameCount = 4;
        // Kolik tiků trvá jeden frame (nižší = rychlejší animace)
        private const int FrameSpeed = 5;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = FrameCount;
        }

        public override void SetDefaults()
        {
            // --- Hitbox ---
            Projectile.width = 14;
            Projectile.height = 14;

            // --- AI ---
            // ProjAIStyleID.Arrow = rovný let vpřed, bez gravitace
            // AIType záměrně nenastavujeme – kopírování AI z Fireballu
            // by převzalo i jeho rotační animaci a způsobovalo by vizuální glitch
            Projectile.aiStyle = ProjAIStyleID.Arrow;

            // --- Kolize ---
            Projectile.friendly = true;   // poškozuje nepřátele, ne hráče
            Projectile.hostile = false;
            Projectile.penetrate = 3;     // prostřelí až 3 nepřátele

            // --- Typ poškození ---
            Projectile.DamageType = DamageClass.Magic;

            // --- Životnost ---
            Projectile.timeLeft = 300;    // zanikne po 5 sekundách

            // --- Vizuál ---
            Projectile.light = 0.5f;      // vydává oranžové světlo
            Projectile.alpha = 20;        // mírná průhlednost
        }

        /// <summary>
        /// Voláno každý tik – animace framů + dust trail efekt.
        /// </summary>
        public override void AI()
        {
            // --- Animace ---
            // frameCounter počítá tiky; po FrameSpeed tikách přepneme na další frame
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= FrameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % FrameCount;
            }

            // --- Dust trail ---
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    DustID.Torch,
                    Scale: 1.2f
                );
            }
        }

        /// <summary>
        /// Voláno při zásahu NPC.
        /// </summary>
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Zapálíme NPC na 3 sekundy (180 tiků)
            target.AddBuff(BuffID.OnFire, 180);
        }

        /// <summary>
        /// Voláno při zániku projektilu (zásah zdi, expirování, atd.).
        /// </summary>
        public override void Kill(int timeLeft)
        {
            // Efekt exploze – 25 jiskřiček
            for (int i = 0; i < 25; i++)
            {
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    DustID.Torch,
                    Scale: Main.rand.NextFloat(1f, 2f)
                );
            }

            // Zvuk exploze
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
        }
    }
}

namespace Cpln.Enigmos.Enigmas.Components
{
    /// <summary>
    /// Contrôleur qui permet de gérer plusieurs lampes.
    /// </summary>
    interface LightController
    {
        /// <summary>
        /// Appelé lorsqu'une lampe change d'état.
        /// </summary>
        /// <returns></returns>
        bool Check();
    }
}
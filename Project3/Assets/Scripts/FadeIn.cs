using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    
    public Image panel;
    Color whiteFlash = new Color(255f, 255f, 255f, 255f);
    Color transparent = new Color(255f, 255f, 255f, 0f);

    /// <summary>
    /// Fades the given panel to a certain color & alpha, over time.
    /// </summary>
    /// <param name="color"> The color/Alpha to fade towards</param>
    /// <param name="fadeTime">How long should this take</param>
    /// <param name="ignoreTimeScale">Should this be a pauseable effect (basically)</param>
    public void PanelFade(Color color, float fadeTime, bool ignoreTimeScale) {
        panel.CrossFadeColor(color, fadeTime, ignoreTimeScale, true);
    }
    public void Flash(){
        panel.color = whiteFlash;
        panel.CrossFadeColor(transparent, 1f, false, true);
    }
}

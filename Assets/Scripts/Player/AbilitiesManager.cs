using UnityEngine;
using System.Collections;

public class AbilitiesManager : MonoBehaviour
{
    [SerializeField] private Ability[] abilities;

    private void Awake()
    {
        Ability.InitializeAbility(GetComponent<PlayerStats>(), transform);
    }

    public void ActivateAbility(string _name)
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i].name == _name)
                abilities[i].FireAbility();
        }
    }
}

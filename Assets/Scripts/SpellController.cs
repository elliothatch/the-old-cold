using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellController : MonoBehaviour {

    [System.Serializable]
    public class Spell
    {
        public GameObject prefab;
        public float baseAttackSpeed = 1.0f;
    }
    public List<Spell> spells;
    protected List<Spell> equippedSpells = new List<Spell>();
    protected float attackCooldown = 0.0f;
	// Use this for initialization
	void Start () {
        equippedSpells.Add(spells[0]);
        equippedSpells.Add(null);
	}
	
	// Update is called once per frame
	void Update () {
        if (attackCooldown > 0.0f)
        {
            attackCooldown -= Time.deltaTime;
        }
	}

    public void equipSpell(Spell spell, int slot)
    {
        equippedSpells[slot] = spell;
    }

    public void cast(int index)
    {
        if (attackCooldown <= 0.0f && index < equippedSpells.Count && equippedSpells[index] != null)
        {
            attackCooldown = equippedSpells[index].baseAttackSpeed;
            Instantiate(equippedSpells[index].prefab, transform.position, transform.rotation);
        }
    }
}

import { Skill } from "./skill";
import { Weapon } from "./weapon";

export class Character{
    id: number;
    name: string;
    hitPoints: number;
    strength: number;
    defense: number;
    intelligence: number;
    class: number;
    weapon: Weapon;
    skills: Skill[];
    fights: number;
    victories: number;
    defeats: number;

}

// public int Id { get; set; }
// public string Name { get; set; } = "Frodo";
// public int HitPoints { get; set; } = 100;
// public int Strength { get; set; } = 10;
// public int Defense { get; set; } = 10;
// public int Intelligence { get; set; } = 10;
// public RpgClass Class { get; set; } = RpgClass.Knight;
// public GetWeaponDto Weapon { get; set; }
// public List<GetSkillDto> Skills { get; set; }
// public int Fights { get; set; }
// public int Victories { get; set; }
// public int Defeats { get; set; }


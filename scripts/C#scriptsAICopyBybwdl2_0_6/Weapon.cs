using System;
using UnityEngine;


// 武器实体类
public class Weapon
{

    // 武器ID
    [SerializeField] public byte weaponId { get; set; }
    // 武器名称
    [SerializeField] public string weaponName { get; set; }
    // 武器价格
    [SerializeField] public short weaponPrice { get; set; }
    // 武器属性
    [SerializeField] public byte weaponProperties { get; set; }
    // 武器重量
    [SerializeField] public byte weaponWeight { get; set; }
    // 武器类型
    [SerializeField] public byte weaponType { get; set; }
    
    // 默认构造函数
    public Weapon() { }

    // 参数化构造函数
    public Weapon(byte weaponId, string weaponName, short weaponPrice, byte weaponProperties, byte weaponWeight, byte weaponType)
    {
        this.weaponId = weaponId;
        this.weaponName = weaponName;
        this.weaponPrice = weaponPrice;
        this.weaponProperties = weaponProperties;
        this.weaponWeight = weaponWeight;
        this.weaponType = weaponType;
    }
}
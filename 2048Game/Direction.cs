// -------------------------------------------------------------
// <copyright file="Direction.cs" company="SuperSight">
//     ©2013 SuperSight Corporation. All rights reserved.	
// </copyright> 
// -------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;


/* ==============================================================
* 
* 作者：Mr.K 
* 时间：2014/5/13 11:39:36
* 版本：V1.0.1
*
* 修改作者： 
* 修改时间： 
* 修改说明：
* ===============================================================
*/
namespace _2048Game
{
    /// <summary>
    /// 方向
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// 不明确的方向
        /// </summary>
        Nil,

        /// <summary>
        /// 上
        /// </summary>
        Up,

        /// <summary>
        /// 下
        /// </summary>
        Down,

        /// <summary>
        /// 左
        /// </summary>
        Left,

        /// <summary>
        /// 右
        /// </summary>
        Right
    }
}

﻿using System;
using System.Collections;
using NetIRC;

namespace DesktopCS.Forms
{
    class UserNodeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            UserNode first = x as UserNode;
            UserNode second = y as UserNode;

            User firstUser = first.User;
            User secondUser = second.User;

            UserRank[] ranks = new UserRank[] {
                UserRank.None,
                UserRank.Voice,
                UserRank.HalfOp,
                UserRank.Op,
                UserRank.Admin,
                UserRank.Owner
            };

            if (firstUser.Rank != secondUser.Rank)
            {
                int firstIndex = Array.IndexOf(ranks, firstUser.Rank);
                int secondIndex = Array.IndexOf(ranks, secondUser.Rank);

                if (firstIndex > secondIndex)
                {
                    return -1;
                }

                return 1;
            }

            return string.Compare(firstUser.NickName, secondUser.NickName, true);
        }
    }
}
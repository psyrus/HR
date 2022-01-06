#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'biggerIsGreater' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING w as parameter.
#


def biggerIsGreater(w):
    # Start from the right side of the string, checking each char to see if there is something LOWER than it in value that can be swapped out to make the overall total rise (the least)
    indexSwapCandidates = []
    wordArray = list(w)
    for i, e in reversed(list(enumerate(w))):
        charVal = ord(e)

        for j in range(i, -1, -1):
            # Once something can be switched, swap them
            if ord(w[j]) < charVal:
                #print(f"For string {w}, character {e} at position {i} could be swapped with character {w[j]} at position {j} because {ord(w[j])} is < {charVal}")
                indexSwapCandidates.append(
                    {
                        "sourceIndex": i,
                        "sourceValue": w[i],
                        "sourceValueInt": ord(w[i]),
                        "targetIndex": j,
                        "targetValue": w[j],
                        "targetValueInt": ord(w[j])
                    }
                )
        # Need to break early if we have exceeded the meaningful number of items to check

    if not indexSwapCandidates:
        return "no answer"

    # Do the swap with the best candidate
    newlist = sorted(indexSwapCandidates, key=lambda d: d['targetIndex'], reverse=True)
    swapItem = newlist[0]
    temp = wordArray[swapItem['sourceIndex']]
    wordArray[swapItem['sourceIndex']] = wordArray[swapItem['targetIndex']]
    wordArray[swapItem['targetIndex']] = temp

    # Then sort the items AFTER the left most swapped index fromm small to large
    sortedSubArray = wordArray[swapItem['targetIndex'] + 1:]
    sortedSubArray.sort()
    return "".join(wordArray[:swapItem['targetIndex'] + 1] + sortedSubArray)


if __name__ == '__main__':
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # T = int(input().strip())

    # for T_itr in range(T):
    #     w = input()

    #     result = biggerIsGreater(w)

    #     fptr.write(result + '\n')

    # fptr.close().

    cases = [
        'dkhc',
        'imllmmcslslkyoegymoa',
        'fvincndjrurfh',
        'rtglgzzqxnuflitnlyit',
        'mhtvaqofxtyrz',
        'zalqxykemvzzgaka',
        'wjjulziszbqqdcpdnhdo',
        'japjbvjlxzkgietkm',
        'jqczvgqywydkunmjw',
        'ehdegnmorgafrjxvksc',
        'tydwixlwghlmqo',
        'wddnwjneaxbwhwamr',
        'pnimbesirfbivxl',
        'mijamkzpiiniveik',
        'qxtwpdpwexuej',
        'qtcshorwyck',
        'xoojiggdcyjrupr',
        'vcjmvngcdyabcmjz',
        'xildrrhpca',
        'rrcntnbqchsfhvijh',
        'kmotatmrabtcomu',
        'bnfcejmyotvw',
        'dnppdkpywiaxddoqx',
        'tmowsxkrodmkkra',
        'jfkaehlegohwggf',
        'ttylsiegnttymtyx',
        'kyetllczuyibdkwyihrq',
        'xdhqbvlbtmmtshefjf',
        'kpdpzzohihzwgdfzgb',
        'kuywptftapaa',
        'qfqpegznnyludrv',
        'ufwogufbzaboaepslikq',
        'jfejqapjvbdcxtkry',
        'sypjbvatgidyxodd',
        'wdpfyqjcpcn',
        'baabpjckkytudr',
        'uvwurzjyzbhcqmrypraq',
        'kvtwtmqygksbim',
        'ivsjycnooeodwpt',
        'zqyxjnnitzawipqsm',
        'blmrzavodtfzyepz',
        'bmqlhqndacv',
        'phvauobwkrcfwdecsd',
        'vpygyqubqywkndhpzw',
        'yikanhdrjxw',
        'vnpblfxmvwkflqobrk',
        'pserilwzxwyorldsxksl',
        'qymbqaehnyzhfqpqprpl',
        'fcakwzuqlzglnibqmkd',
        'jkscckttaeifiksgkmxx',
        'dkbllravwnhhfjjrce',
        'imzsyrykfvjt',
        'tvogoocldlukwfcajvix',
        'cvnagtypozljpragvlj',
        'hwcmacxvmus',
        'rhrzcpprqccf',
        'clppxvwtaktchqrdif',
        'qwusnlldnolhq',
        'yitveovrja',
        'arciyxaxtvmfgquwb',
        'pzbxvxdjuuvuv',
        'nxfowilpdxwlpt',
        'swzsaynxbytytqtq',
        'qyrogefleeyt',
        'iotjgthvslvmjpcchhuf',
        'knfpyjtzfq',
        'tmtbfayantmwk',
        'asxwzygngwn',
        'rmwiwrurubt',
        'bhmpfwhgqfcqfldlhs',
        'yhbidtewpgp',
        'jwwbeuiklpodvzii',
        'anjhprmkwibe',
        'lpwhqaebmr',
        'dunecynelymcpyonjq',
        'hblfldireuivzekegit',
        'uryygzpwifrricwvge',
        'kzuhaysegaxtwqtvx',
        'kvarmrbpoxxujhvgpw',
        'hanhaggqzdpunkugzmhq',
        'gnwqwsylqeuqr',
        'qzkjbnyvclrkmdtc',
        'argsnaqbquv',
        'obbnlkoaklcx',
        'ojiilqieycsasvqosycu',
        'qhlgiwsmtxbffjsxt',
        'vvrvnmndeogyp',
        'ibeqzyeuvfzb',
        'sajpyegttujxyx',
        'zmdjphzogfldlkgbchnt',
        'tbanvjmwirxx',
        'gmdhdlmopzyvddeqyjja',
        'yxvmvedubzcpd',
        'soygdzhbckfuk',
        'gkbekyrhcwc',
        'wevzqpnqwtpfu',
        'rbobquotbysufwqjeo',
        'bpgqfwoyntuhkvwo',
        'schtabphairewhfmp',
        'rlmrahlisggguykeu',
        'fjtfrmlqvsekq'
    ]
    expectedOutput = [
        'hcdk',
        'imllmmcslslkyoegyoam',
        'fvincndjrurhf',
        'rtglgzzqxnuflitnlyti',
        'mhtvaqofxtyzr',
        'zalqxykemvzzgkaa',
        'wjjulziszbqqdcpdnhod',
        'japjbvjlxzkgietmk',
        'jqczvgqywydkunmwj',
        'ehdegnmorgafrjxvsck',
        'tydwixlwghlomq',
        'wddnwjneaxbwhwarm',
        'pnimbesirfbixlv',
        'mijamkzpiiniveki',
        'qxtwpdpwexuje',
        'qtcshorwykc',
        'xoojiggdcyjrurp',
        'vcjmvngcdyabcmzj',
        'xildrrpach',
        'rrcntnbqchsfhvjhi',
        'kmotatmrabtcoum',
        'bnfcejmyotwv',
        'dnppdkpywiaxddoxq',
        'tmowsxkrodmkrak',
        'jfkaehlegowfggh',
        'ttylsiegnttymxty',
        'kyetllczuyibdkwyiqhr',
        'xdhqbvlbtmmtshejff',
        'kpdpzzohihzwgdgbfz',
        'kuywptftpaaa',
        'qfqpegznnyludvr',
        'ufwogufbzaboaepsliqk',
        'jfejqapjvbdcxtkyr',
        'sypjbvatgiodddxy',
        'wdpfyqjcpnc',
        'baabpjckkyturd',
        'uvwurzjyzbhcqmryprqa',
        'kvtwtmqygksbmi',
        'ivsjycnooeodwtp',
        'zqyxjnnitzawipsmq',
        'blmrzavodtfzyezp',
        'bmqlhqndavc',
        'phvauobwkrcfwdedcs',
        'vpygyqubqywkndhwpz',
        'yikanhdrwjx',
        'vnpblfxmvwkflqokbr',
        'pserilwzxwyorldsxlks',
        'qymbqaehnyzhfqpqrlpp',
        'fcakwzuqlzglnidbkmq',
        'jkscckttaeifiksgkxmx',
        'dkbllravwnhhfjjrec',
        'imzsyrykfvtj',
        'tvogoocldlukwfcajvxi',
        'cvnagtypozljprajglv',
        'hwcmacxvsmu',
        'rhrzcpprqcfc',
        'clppxvwtaktchqrfdi',
        'qwusnlldnolqh',
        'yitverajov',
        'arciyxaxtvmfgqwbu',
        'pzbxvxdjuuvvu',
        'nxfowilpdxwltp',
        'swzsaynxbytyttqq',
        'qyrogefletey',
        'iotjgthvslvmjpcchufh',
        'knfpyjtzqf',
        'tmtbfayantwkm',
        'asxwzygnngw',
        'rmwiwrurutb',
        'bhmpfwhgqfcqfldlsh',
        'yhbidtewppg',
        'jwwbeuiklpodziiv',
        'anjhprmkwieb',
        'lpwhqaebrm',
        'dunecynelymcpyonqj',
        'hblfldireuivzekegti',
        'uryygzpwifrriecgvw',
        'kzuhaysegaxtwqtxv',
        'kvarmrbpoxxujhvgwp',
        'hanhaggqzdpunkugzmqh',
        'gnwqwsylqeurq',
        'qzkjbnyvclrkmtcd',
        'argsnaqbqvu',
        'obbnlkoaklxc',
        'ojiilqieycsasvqosyuc',
        'qhlgiwsmtxbffjtsx',
        'vvrvnmndeopgy',
        'ibeqzyeuvzbf',
        'sajpyegttujyxx',
        'zmdjphzogfldlkgbchtn',
        'tbanvjmwixrx',
        'gmdhdlmopzyvddeyajjq',
        'yxvmvedubzdcp',
        'soygdzhbckkfu',
        'gkbekyrhwcc',
        'wevzqpnqwtpuf',
        'rbobquotbysufwqjoe',
        'bpgqfwoyntuhkwov',
        'schtabphairewhfpm',
        'rlmrahlisggguykue',
        'fjtfrmlqvseqk'
    ]

    for i, c in enumerate(cases):
        result = biggerIsGreater(c)
        if expectedOutput[i] != result:
            print(f"Case ({i}): \n\t[{c}]\n\t[{expectedOutput[i]}] ✅\n\t[{result}] ✖")
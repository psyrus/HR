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
    swappedIndex = -1
    wordArray = list(w)
    for i, e in reversed(list(enumerate(w))):
        charVal = ord(e)

        for j in range(i, -1, -1):
            # Once something can be switched, swap them
            if ord(w[j]) < charVal:
                #print(f"For string {w}, character {e} at position {i} should be swapped with character {w[j]} at position {j} because {ord(w[j])} is < {charVal}")
                temp = wordArray[j]
                wordArray[j] = e
                wordArray[i] = temp
                swappedIndex = j
                break
        if swappedIndex != -1:
            break

    if swappedIndex == -1:
        return "no answer"
    # Then sort the items AFTER the left most swapped index fromm small to large
    sortedSubArray = wordArray[swappedIndex + 1:]
    sortedSubArray.sort()
    return "".join(wordArray[:swappedIndex + 1] + sortedSubArray)


if __name__ == '__main__':
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # T = int(input().strip())

    # for T_itr in range(T):
    #     w = input()

    #     result = biggerIsGreater(w)

    #     fptr.write(result + '\n')

    # fptr.close().

    cases = [
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
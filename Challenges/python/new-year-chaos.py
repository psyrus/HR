#!/bin/python3
# https://www.hackerrank.com/challenges/new-year-chaos/problem

import math
import os
import random
import re
import sys

#
# Complete the 'minimumBribes' function below.
#
# The function accepts INTEGER_ARRAY q as parameter.
#

# Each person can bribe to move one spot higher in the queue
# Each person can only bribe twice
# original spot in queue is held on a "sticker" on each person
def minimumBribes(q):
    # First need to check if any item is >2 lower than it originally was -> Instant return of "too chaotic"
    # Otherwise just return the total delta of positions of anything that is higher than a current position's expected value
    total_bribes = 0
    for idx, val in enumerate(q):
        exp_val = idx + 1
        val_diff = val - exp_val
        if val_diff > 2:
            print("Too chaotic")
            return
        # Need to prevennt a timeout here by skipping loop items we don't need
        # Don't need to loop from 0, but just from its original index (val - 2)
        loop_start = 0 if val == 1 else val - 2
        for i in range(loop_start, idx):
            if q[i] > val:
                total_bribes += 1

    print(total_bribes)

if __name__ == '__main__':
    # t = int(input().strip())

    # for t_itr in range(t):
    #     n = int(input().strip())

    #     q = list(map(int, input().rstrip().split()))

    #     minimumBribes(q)
    minimumBribes([2, 1, 5, 3, 4])
    minimumBribes([2, 5, 1, 3, 4])
    minimumBribes([1, 2, 5, 3, 7, 8, 6, 4])
    minimumBribes([2, 1, 5, 6, 3, 4, 9, 8, 11, 7, 10, 14, 13, 12, 17, 16, 15, 19, 18, 22, 20, 24, 23, 21, 27, 28, 25, 26, 30, 29, 33, 32, 31, 35, 36, 34, 39, 38, 37, 42, 40, 44, 41, 43, 47, 46, 48, 45, 50, 52, 49, 51, 54, 56, 55, 53, 59, 58, 57, 61, 63, 60, 65, 64, 67, 68, 62, 69, 66, 72, 70, 74, 73, 71, 77, 75, 79, 78, 81, 82, 80, 76, 85, 84, 83, 86, 89, 90, 88, 87, 92, 91, 95, 94, 93, 98, 97, 100, 96, 102, 99, 104, 101, 105, 103, 108, 106, 109, 107, 112, 111, 110, 113, 116, 114, 118, 119, 117, 115, 122, 121, 120, 124, 123, 127, 125, 126, 130, 129, 128, 131, 133, 135, 136, 132, 134, 139, 140, 138, 137, 143, 141, 144, 146, 145, 142, 148, 150, 147, 149, 153, 152, 155, 151, 157, 154, 158, 159, 156, 161, 160, 164, 165, 163, 167, 166, 162, 170, 171, 172, 168, 169, 175, 173, 174, 177, 176, 180, 181, 178, 179, 183, 182, 184, 187, 188, 185, 190, 189, 186, 191, 194, 192, 196, 197, 195, 199, 193, 198, 202, 200, 204, 205, 203, 207, 206, 201, 210, 209, 211, 208, 214, 215, 216, 212, 218, 217, 220, 213, 222, 219, 224, 221, 223, 227, 226, 225, 230, 231, 229, 228, 234, 235, 233, 237, 232, 239, 236, 241, 238, 240, 243, 242, 246, 245, 248, 249, 250, 247, 244, 253, 252, 251, 256, 255, 258, 254, 257, 259, 261, 262, 263, 265, 264, 260, 268, 266, 267, 271, 270, 273, 269, 274, 272, 275, 278, 276, 279, 277, 282, 283, 280, 281, 286, 284, 288, 287, 290, 289, 285, 293, 291, 292, 296, 294, 298, 297, 299, 295, 302, 301, 304, 303, 306, 300, 305, 309, 308, 307, 312, 311, 314, 315, 313, 310, 316, 319, 318, 321, 320, 317, 324, 325, 322, 323, 328, 327, 330, 326, 332, 331, 329, 335, 334, 333, 336, 338, 337, 341, 340, 339, 344, 343, 342, 347, 345, 349, 346, 351, 350, 348, 353, 355, 352, 357, 358, 354, 356, 359, 361, 360, 364, 362, 366, 365, 363, 368, 370, 367, 371, 372, 369, 374, 373, 376, 375, 378, 379, 377, 382, 381, 383, 380, 386, 387, 384, 385, 390, 388, 392, 391, 389, 393, 396, 397, 394, 398, 395, 401, 400, 403, 402, 399, 405, 407, 406, 409, 408, 411, 410, 404, 413, 412, 415, 417, 416, 414, 420, 419, 422, 421, 418, 424, 426, 423, 425, 428, 427, 431, 430, 429, 434, 435, 436, 437, 432, 433, 440, 438, 439, 443, 441, 445, 442, 447, 444, 448, 446, 449, 452, 451, 450, 455, 453, 454, 457, 456, 460, 459, 458, 463, 462, 464, 461, 467, 465, 466, 470, 469, 472, 468, 474, 471, 475, 473, 477, 476, 480, 479, 478, 483, 482, 485, 481, 487, 484, 489, 490, 491, 488, 492, 486, 494, 495, 496, 498, 493, 500, 499, 497, 502, 504, 501, 503, 507, 506, 505, 509, 511, 508, 513, 510, 512, 514, 516, 518, 519, 515, 521, 522, 520, 524, 517, 523, 525, 526, 529, 527, 531, 528, 533, 532, 534, 530, 537, 536, 539, 535, 541, 538, 540, 543, 544, 542, 547, 548, 545, 549, 546, 552, 550, 551, 554, 553, 557, 555, 556, 560, 559, 558, 563, 562, 564, 561, 567, 568, 566, 565, 569, 572, 571, 570, 575, 574, 577, 576, 579, 573, 580, 578, 583, 581, 584, 582, 587, 586, 585, 590, 589, 588, 593, 594, 592, 595, 591, 598, 599, 596, 597, 602, 603, 604, 605, 600, 601, 608, 609, 607, 611, 612, 606, 610, 615, 616, 614, 613, 619, 618, 617, 622, 620, 624, 621, 626, 625, 623, 628, 627, 631, 630, 633, 629, 635, 632, 637, 636, 634, 638, 640, 642, 639, 641, 645, 644, 647, 643, 646, 650, 648, 652, 653, 654, 649, 651, 656, 658, 657, 655, 661, 659, 660, 663, 664, 666, 662, 668, 667, 670, 665, 671, 673, 669, 672, 676, 677, 674, 679, 675, 680, 678, 681, 684, 682, 686, 685, 683, 689, 690, 688, 687, 693, 692, 691, 696, 695, 698, 694, 700, 701, 702, 697, 704, 699, 706, 703, 705, 709, 707, 711, 712, 710, 708, 713, 716, 715, 714, 718, 720, 721, 719, 723, 717, 722, 726, 725, 724, 729, 728, 727, 730, 733, 732, 735, 734, 736, 731, 738, 737, 741, 739, 740, 744, 743, 742, 747, 746, 745, 750, 748, 752, 749, 753, 751, 756, 754, 758, 755, 757, 761, 760, 759, 764, 763, 762, 767, 765, 768, 766, 771, 770, 769, 774, 773, 776, 772, 778, 777, 779, 775, 781, 780, 783, 784, 782, 786, 788, 789, 787, 790, 785, 793, 791, 792, 796, 795, 794, 798, 797, 801, 799, 803, 800, 805, 802, 804, 808, 806, 807, 811, 809, 810, 814, 812, 813, 817, 816, 819, 818, 815, 820, 821, 823, 822, 824, 826, 827, 825, 828, 831, 829, 830, 834, 833, 836, 832, 837, 839, 838, 841, 835, 840, 844, 842, 846, 845, 843, 849, 847, 851, 850, 852, 848, 855, 854, 853, 857, 856, 858, 861, 862, 860, 859, 863, 866, 865, 864, 867, 870, 869, 868, 872, 874, 875, 871, 873, 877, 878, 876, 880, 881, 879, 884, 883, 885, 882, 888, 886, 890, 891, 889, 893, 887, 895, 892, 896, 898, 894, 899, 897, 902, 901, 903, 905, 900, 904, 908, 907, 910, 909, 906, 912, 911, 915, 913, 916, 918, 914, 919, 921, 917, 923, 920, 924, 922, 927, 925, 929, 928, 926, 932, 931, 934, 930, 933, 935, 937, 939, 940, 938, 936, 943, 944, 942, 941, 947, 946, 948, 945, 951, 950, 949, 953, 952, 956, 954, 958, 957, 955, 961, 962, 963, 959, 964, 966, 960, 965, 969, 968, 971, 967, 970, 974, 972, 976, 973, 975, 979, 977, 981, 982, 978, 980, 983, 986, 984, 985, 989, 988, 987, 990, 993, 991, 995, 994, 997, 992, 999, 1000, 996, 998])
    # minimumBribes([3, 1, 5, 4, 2, 8, 6, 10, 11, 9, 13, 7, 15, 12, 17, 18, 19, 20, 16, 14, 23, 21, 25, 24, 27, 26, 22, 30, 31, 29, 28, 34, 33, 32, 37, 35, 39, 40, 41, 38, 36, 44, 45, 46, 43, 42, 49, 48, 47, 52, 53, 50, 55, 54, 51, 58, 59, 60, 57, 56, 63, 64, 61, 66, 65, 68, 69, 67, 62, 72, 71, 74, 70, 76, 75, 73, 79, 78, 81, 82, 77, 84, 83, 86, 80, 88, 87, 85, 91, 90, 89, 94, 92, 96, 95, 93, 99, 98, 101, 100, 103, 97, 105, 104, 102, 108, 109, 110, 106, 112, 111, 114, 115, 113, 107, 118, 117, 116, 121, 122, 120, 119, 125, 124, 123, 128, 127, 126, 131, 129, 133, 134, 132, 136, 130, 138, 137, 135, 141, 139, 143, 144, 142, 140, 147, 145, 149, 148, 146, 152, 151, 154, 153, 150, 157, 158, 159, 156, 155, 162, 163, 164, 160, 166, 167, 165, 161, 170, 171, 169, 173, 172, 168, 176, 175, 174, 179, 178, 181, 182, 180, 177, 185, 184, 183, 188, 187, 186, 191, 192, 190, 189, 195, 196, 194, 193, 199, 197, 201, 200, 198, 204, 203, 206, 207, 208, 205, 202, 211, 210, 213, 212, 209, 216, 215, 214, 219, 218, 217, 222, 221, 224, 223, 220, 227, 226, 225, 230, 231, 229, 233, 234, 235, 232, 228, 238, 236, 240, 241, 242, 239, 237, 245, 246, 244, 243, 249, 250, 248, 247, 253, 254, 252, 256, 251, 258, 255, 260, 261, 259, 257, 264, 263, 266, 267, 262, 269, 265, 271, 272, 273, 270, 268, 276, 275, 278, 274, 280, 279, 277, 283, 282, 281, 286, 287, 284, 289, 288, 285, 292, 293, 291, 295, 294, 290, 298, 296, 300, 299, 297, 303, 302, 301, 306, 305, 304, 309, 307, 311, 312, 310, 308, 315, 314, 313, 318, 316, 320, 321, 317, 323, 319, 325, 326, 324, 322, 329, 327, 331, 332, 330, 334, 333, 328, 337, 336, 335, 340, 338, 342, 341, 344, 343, 339, 347, 345, 349, 350, 348, 346, 353, 352, 351, 356, 355, 358, 359, 357, 361, 354, 363, 362, 360, 366, 365, 364, 369, 368, 367, 372, 370, 374, 371, 376, 373, 378, 379, 377, 375, 382, 380, 384, 385, 383, 381, 388, 389, 390, 386, 392, 387, 394, 393, 391, 397, 398, 399, 396, 395, 402, 403, 404, 401, 400, 407, 405, 409, 406, 411, 412, 410, 414, 408, 416, 415, 413, 419, 420, 421, 418, 423, 417, 425, 426, 422, 428, 424, 430, 431, 429, 433, 432, 427, 436, 435, 434, 439, 440, 437, 442, 438, 444, 441, 446, 445, 443, 449, 447, 451, 448, 453, 452, 450, 456, 457, 454, 459, 455, 461, 458, 463, 460, 465, 464, 462, 468, 467, 470, 469, 472, 471, 466, 475, 473, 477, 476, 479, 478, 474, 482, 481, 484, 480, 486, 483, 488, 485, 490, 487, 492, 489, 494, 493, 491, 497, 496, 499, 498, 495, 502, 500, 504, 501, 506, 505, 503, 509, 508, 511, 507, 513, 510, 515, 516, 517, 512, 519, 514, 521, 520, 518, 524, 525, 523, 522, 528, 526, 530, 531, 529, 527, 534, 533, 536, 535, 532, 539, 540, 538, 537, 543, 544, 541, 546, 542, 548, 547, 550, 551, 549, 545, 554, 553, 556, 552, 558, 559, 557, 555, 562, 561, 564, 560, 566, 567, 565, 569, 568, 563, 572, 573, 570, 575, 571, 577, 576, 574, 580, 581, 579, 578, 584, 583, 582, 587, 585, 589, 586, 591, 590, 593, 592, 588, 596, 597, 595, 594, 600, 599, 602, 598, 604, 601, 606, 605, 603, 609, 608, 607, 612, 613, 614, 615, 611, 610, 618, 617, 616, 621, 619, 623, 624, 625, 622, 627, 626, 629, 628, 620, 632, 631, 630, 635, 634, 637, 636, 633, 640, 639, 642, 638, 644, 641, 646, 647, 645, 643, 650, 651, 652, 653, 649, 648, 656, 657, 655, 654, 660, 661, 659, 663, 658, 665, 662, 667, 666, 664, 670, 669, 668, 673, 671, 675, 674, 677, 678, 676, 672, 681, 680, 679, 684, 682, 686, 687, 685, 689, 688, 683, 692, 693, 691, 695, 696, 697, 690, 699, 700, 698, 694, 703, 701, 705, 704, 702, 708, 707, 706, 711, 712, 710, 709, 715, 713, 717, 714, 719, 718, 716, 722, 723, 721, 720, 726, 725, 724, 729, 730, 728, 732, 727, 734, 731, 736, 733, 738, 735, 740, 739, 737, 743, 742, 741, 746, 747, 745, 744, 750, 751, 749, 748, 754, 755, 753, 752, 758, 759, 757, 761, 762, 760, 756, 765, 764, 763, 768, 769, 767, 766, 772, 773, 774, 771, 770, 777, 778, 776, 775, 781, 779, 783, 780, 785, 782, 787, 786, 789, 788, 784, 792, 790, 794, 791, 796, 795, 798, 797, 793, 801, 800, 799, 804, 803, 806, 805, 802, 809, 810, 808, 807, 813, 814, 812, 811, 817, 815, 819, 820, 821, 818, 816, 824, 825, 823, 827, 822, 829, 828, 826, 832, 833, 830, 835, 834, 831, 838, 837, 836, 841, 840, 843, 844, 842, 839, 847, 845, 849, 848, 851, 850, 846, 854, 853, 852, 857, 856, 859, 858, 855, 862, 861, 864, 860, 866, 863, 868, 869, 867, 865, 872, 870, 874, 875, 871, 877, 878, 876, 880, 873, 882, 881, 879, 885, 884, 887, 886, 883, 890, 891, 889, 888, 894, 895, 892, 897, 898, 896, 893, 901, 900, 903, 902, 899, 906, 905, 908, 907, 904, 911, 909, 913, 910, 915, 916, 914, 912, 919, 917, 921, 918, 923, 920, 925, 924, 922, 928, 929, 927, 931, 926, 933, 934, 932, 930, 937, 936, 935, 940, 941, 939, 938, 944, 945, 946, 943, 942, 949, 948, 947, 952, 951, 950, 955, 953, 957, 956, 954, 960, 961, 959, 958, 964, 965, 962, 967, 968, 966, 963, 971, 970, 973, 974, 969, 976, 972, 978, 977, 980, 981, 979, 975, 984, 982, 986, 987, 983, 989, 988, 985, 992, 991, 990, 995, 996, 993, 998, 997, 1000, 999, 994])


# 2 1 5 3 4
# 1 2 3 4 5
#



# 1 2 5 3 7 8 6 4
# 1 2 3 4 5 6 7 8
# 0 0 2 - 2 2 1 -
#######
# 1 2 5 3  7 8  6  4
# 1 2 3 4  5 6  7  8
# 0 0 2 -1 2 2 -1 -4

# How many instances of larger items appearing before smaller items
# "should have been seen but havent" array and just compare against that one (length)
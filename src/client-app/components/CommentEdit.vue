<template>
    <v-card>
                <v-card-title>
                By: <nuxt-link to="./">{{commenter}}</nuxt-link>
                </v-card-title>
                <v-card-text>
                    <nuxt-link to="./">{{url}}</nuxt-link>
                    <v-btn
                        class="red accent-3"
                        depressed
                    >
                        DELETE COMMENT
                    </v-btn>
                </v-card-text>
    </v-card>
</template>

<script>
export default {
    name:'CommentsEdit',
    props:{
        url:{
            type:String,
            required:true
        },
        commenter:{
            type:String,
            required:true
        }
    }
}
</script>

<style>

</style>
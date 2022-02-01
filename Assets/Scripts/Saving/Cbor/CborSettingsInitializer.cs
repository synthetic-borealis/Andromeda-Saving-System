#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor;
using Dahomey.Cbor.Attributes;
using Dahomey.Cbor.Serialization.Converters;
using UnityEngine;

namespace Andromeda.Saving.Cbor
{
    public static class CborSettingsInitializer
    {
        private static bool _isInitialised = false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void OnBeforeSplashScreen() => Initialise();

#if UNITY_EDITOR
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded() => Initialise();
#endif // UNITY_EDITOR

        private static void Initialise()
        {
            if (_isInitialised) return;

            CborOptions.Default.MapLengthMode = LengthMode.IndefiniteLength;
            CborOptions.Default.ArrayLengthMode = LengthMode.IndefiniteLength;
            CborOptions.Default.DiscriminatorPolicy = CborDiscriminatorPolicy.Always;

            // Math
            #region Math Types
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Vector2));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Vector2>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Vector2),
                new ObjectConverter<Vector2>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Vector2Int));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Vector2Int>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.Initialize();
            });

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Vector3));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Vector3>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.MapMember(m => m.z).SetMemberName("z");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Vector3),
                new ObjectConverter<Vector3>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Vector3Int));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Vector3Int>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.MapMember(m => m.z).SetMemberName("z");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Vector3Int),
                new ObjectConverter<Vector3Int>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Vector4));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Vector4>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.MapMember(m => m.z).SetMemberName("z");
                om.MapMember(m => m.w).SetMemberName("w");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Vector4),
                new ObjectConverter<Vector4>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Quaternion));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Quaternion>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.MapMember(m => m.z).SetMemberName("z");
                om.MapMember(m => m.w).SetMemberName("w");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Quaternion),
                new ObjectConverter<Quaternion>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Color));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Color>(om =>
            {
                om.MapMember(m => m.r).SetMemberName("r");
                om.MapMember(m => m.g).SetMemberName("g");
                om.MapMember(m => m.b).SetMemberName("b");
                om.MapMember(m => m.a).SetMemberName("a");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Color),
                new ObjectConverter<Color>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Color32));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Color32>(om =>
            {
                om.MapMember(m => m.r).SetMemberName("r");
                om.MapMember(m => m.g).SetMemberName("g");
                om.MapMember(m => m.b).SetMemberName("b");
                om.MapMember(m => m.a).SetMemberName("a");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Color32),
                new ObjectConverter<Color32>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Matrix4x4));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Matrix4x4>(om =>
            {
                om.MapMember(m => m.m00).SetMemberName("m00");
                om.MapMember(m => m.m01).SetMemberName("m01");
                om.MapMember(m => m.m02).SetMemberName("m02");
                om.MapMember(m => m.m03).SetMemberName("m03");
                om.MapMember(m => m.m10).SetMemberName("m10");
                om.MapMember(m => m.m11).SetMemberName("m11");
                om.MapMember(m => m.m12).SetMemberName("m12");
                om.MapMember(m => m.m13).SetMemberName("m13");
                om.MapMember(m => m.m20).SetMemberName("m20");
                om.MapMember(m => m.m21).SetMemberName("m21");
                om.MapMember(m => m.m22).SetMemberName("m22");
                om.MapMember(m => m.m23).SetMemberName("m23");
                om.MapMember(m => m.m30).SetMemberName("m30");
                om.MapMember(m => m.m31).SetMemberName("m31");
                om.MapMember(m => m.m32).SetMemberName("m32");
                om.MapMember(m => m.m33).SetMemberName("m33");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Matrix4x4),
                new ObjectConverter<Matrix4x4>(CborOptions.Default));
            #endregion // Math Types

            // Geometry
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Bounds));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Bounds>(om =>
            {
                om.MapMember(m => m.center).SetMemberName("center");
                om.MapMember(m => m.size).SetMemberName("size");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Bounds),
                new ObjectConverter<Bounds>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(BoundsInt));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<BoundsInt>(om =>
            {
                om.MapMember(m => m.center).SetMemberName("center");
                om.MapMember(m => m.size).SetMemberName("size");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(BoundsInt),
                new ObjectConverter<BoundsInt>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(BoundingSphere));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<BoundingSphere>(om =>
            {
                om.MapMember(m => m.position).SetMemberName("position");
                om.MapMember(m => m.radius).SetMemberName("radius");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(BoundingSphere),
                new ObjectConverter<BoundingSphere>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Rect));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Rect>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.MapMember(m => m.width).SetMemberName("width");
                om.MapMember(m => m.height).SetMemberName("height");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Rect),
                new ObjectConverter<Rect>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(RectOffset));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<RectOffset>(om =>
            {
                om.MapMember(m => m.left).SetMemberName("left");
                om.MapMember(m => m.right).SetMemberName("right");
                om.MapMember(m => m.top).SetMemberName("top");
                om.MapMember(m => m.bottom).SetMemberName("bottom");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(RectOffset),
                new ObjectConverter<RectOffset>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(RectInt));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<RectInt>(om =>
            {
                om.MapMember(m => m.x).SetMemberName("x");
                om.MapMember(m => m.y).SetMemberName("y");
                om.MapMember(m => m.width).SetMemberName("width");
                om.MapMember(m => m.height).SetMemberName("height");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(RectInt),
                new ObjectConverter<RectInt>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(RangeInt));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<RangeInt>(om =>
            {
                om.MapMember(m => m.start).SetMemberName("start");
                om.MapMember(m => m.length).SetMemberName("length");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(RangeInt),
                new ObjectConverter<RangeInt>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Plane));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Plane>(om =>
            {
                om.MapMember(m => m.normal).SetMemberName("normal");
                om.MapMember(m => m.distance).SetMemberName("distance");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Plane),
                new ObjectConverter<Plane>(CborOptions.Default));

            // Physics
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Ray));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Ray>(om =>
            {
                om.MapMember(m => m.origin).SetMemberName("origin");
                om.MapMember(m => m.direction).SetMemberName("direction");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Ray),
                new ObjectConverter<Ray>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Ray2D));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Ray2D>(om =>
            {
                om.MapMember(m => m.origin).SetMemberName("origin");
                om.MapMember(m => m.direction).SetMemberName("direction");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Ray2D),
                new ObjectConverter<Ray2D>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(LayerMask));
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(LayerMask), new LayerMaskConverter());

            // Gradient
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(GradientAlphaKey));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<GradientAlphaKey>(om =>
            {
                om.MapMember(m => m.alpha).SetMemberName("alpha");
                om.MapMember(m => m.time).SetMemberName("time");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(GradientAlphaKey),
                new ObjectConverter<GradientAlphaKey>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(GradientColorKey));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<GradientColorKey>(om =>
            {
                om.MapMember(m => m.color).SetMemberName("color");
                om.MapMember(m => m.time).SetMemberName("time");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(GradientColorKey),
                new ObjectConverter<GradientColorKey>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Gradient));
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Gradient), new GradientConverter());

            // Animation Curves
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Keyframe));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<Keyframe>(om =>
            {
                om.MapMember(m => m.time).SetMemberName("time");
                om.MapMember(m => m.value).SetMemberName("value");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Keyframe),
                new ObjectConverter<Keyframe>(CborOptions.Default));

            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(AnimationCurve));
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(AnimationCurve), new AnimationCurveConverter());

            // Particle Systems
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(ParticleSystem.Particle));
            CborOptions.Default.Registry.ObjectMappingRegistry.Register<ParticleSystem.Particle>(om =>
            {
                om.MapMember(m => m.angularVelocity).SetMemberName("angularVelocity");
                om.MapMember(m => m.angularVelocity3D).SetMemberName("angularVelocity3D");
                om.MapMember(m => m.animatedVelocity).SetMemberName("animatedVelocity");
                om.MapMember(m => m.axisOfRotation).SetMemberName("axisOfRotation");
                om.MapMember(m => m.position).SetMemberName("position");
                om.MapMember(m => m.randomSeed).SetMemberName("randomSeed");
                om.MapMember(m => m.remainingLifetime).SetMemberName("remainingLifetime");
                om.MapMember(m => m.rotation).SetMemberName("rotation");
                om.MapMember(m => m.rotation3D).SetMemberName("rotation3D");
                om.MapMember(m => m.startColor).SetMemberName("startColor");
                om.MapMember(m => m.startLifetime).SetMemberName("startLifetime");
                om.MapMember(m => m.startSize).SetMemberName("startSize");
                om.MapMember(m => m.startSize3D).SetMemberName("startSize3D");
                om.MapMember(m => m.totalVelocity).SetMemberName("totalVelocity");
                om.MapMember(m => m.velocity).SetMemberName("velocity");
                om.Initialize();
            });
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(ParticleSystem.Particle),
                new ObjectConverter<ParticleSystem.Particle>(CborOptions.Default));

            // Hashing
            CborOptions.Default.Registry.DiscriminatorConventionRegistry.RegisterType(typeof(Hash128));
            CborOptions.Default.Registry.ConverterRegistry.RegisterConverter(typeof(Hash128), new Hash128Converter());

            _isInitialised = true;
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
